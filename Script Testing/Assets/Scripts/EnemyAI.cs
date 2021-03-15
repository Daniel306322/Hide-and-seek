using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 15f;
    public float objRadius = 5000f;
    public float doorRadius = 5f;
    public Transform[] points;
    public bool closedoors = false;
    public bool objectiveclose = false;
    public bool objectiveclose1 = false;
    public bool objectiveclose2 = false;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Transform player;
    Transform objective;
    Transform objective1;
    Transform objective2;
  /*  Transform door;*/
    public GameObject Objective;
    public GameObject closesthiding = null;
  /*  public GameObject closestdoor = null; */

    void Start()
    {
        player = PlayerManager.instance.Player.transform;
        objective = PlayerManager.instance.Objective.transform;
        objective1 = PlayerManager.instance.Objective1.transform;
        objective2 = PlayerManager.instance.Objective2.transform; 
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
      /*  door = PlayerManager.instance.Door.transform; */
    }

    void Update()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        float objdistance = Vector3.Distance(objective.position, transform.position);
        float objdistance1 = Vector3.Distance(objective1.position, transform.position);
        float objdistance2 = Vector3.Distance(objective2.position, transform.position);
       /* float doordistance = Vector3.Distance(closestdoor.transform.position, transform.position); */

        if (playerdistance <= lookRadius)
        {
            StartCoroutine("Hide");
            closedoors = true;
        }

        if (playerdistance > lookRadius)
        {
            closedoors = false;
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Patrol();
        }

        if (objdistance <= objRadius)
        {
            
            objectiveclose = true;
        }

        if (objdistance1 <= objRadius)
        {
          
            objectiveclose1 = true;
        }

        if (objdistance2 <= objRadius)
        {
          
            objectiveclose2 = true;
        }

      /*  if (doordistance <= doorRadius)
          {
              if (closedoors == true)
              {
                  DoorClose();
              } 
          } */
        if (objdistance > objRadius)
        {
            Patrol();
            objectiveclose = false;
        }

        if (objdistance1 > objRadius)
        {
            Patrol();
            objectiveclose1 = false;
        }

        if (objdistance2 > objRadius)
        {
            Patrol();
            objectiveclose2 = false;
        }

        if (closedoors == false)
        {
            Patrol();
        }

        if (objectiveclose == true)
        {
            Objectiverun();
        }

        if (objectiveclose1 == true)
        {
            Objectiverun1();
        }
        if (objectiveclose2 == true)
        {
            Objectiverun2();
        }

    }

    public GameObject FindClosestHiding()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Hiding");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closesthiding = go;
                distance = curDistance;
            }
        }
        return closesthiding;
    } 

  /*  public GameObject FindClosestDoor()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("DoorTrigger");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestdoor = go;
                distance = curDistance;
            }
        }
        return closestdoor;
    }  */

    void Patrol()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        float objdistance = Vector3.Distance(objective.position, transform.position);
        float objdistance1 = Vector3.Distance(objective1.position, transform.position);
        float objdistance2 = Vector3.Distance(objective2.position, transform.position);

        if (playerdistance <= lookRadius)
        {
            FindClosestHiding();
            agent.SetDestination(closesthiding.transform.position);
            closedoors = true;
        }

        if (objdistance <= objRadius)
        {
            Objectiverun();
        }

        if (objdistance1 <= objRadius)
        {
            Objectiverun1();
        }

        if (objdistance2 <= objRadius)
        {
            Objectiverun2();
        }

        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position; 
        destPoint = (destPoint + 1) % points.Length;
    }

    IEnumerator Hide()
    {
        FindClosestHiding();
        agent.SetDestination(closesthiding.transform.position);
        yield return new WaitForSeconds(0.1f);
    }

    void Objectiverun()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(objective.transform.position);

        if (playerdistance <= lookRadius)
        {
            FindClosestHiding();
            agent.SetDestination(closesthiding.transform.position);
            closedoors = true;
        }
    }

    void Objectiverun1()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(objective1.transform.position);

        if (playerdistance <= lookRadius)
        {
            FindClosestHiding();
            agent.SetDestination(closesthiding.transform.position);
            closedoors = true;
        }
    }

    void Objectiverun2()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(objective2.transform.position);

        if (playerdistance <= lookRadius)
        {
            FindClosestHiding();
            agent.SetDestination(closesthiding.transform.position);
            closedoors = true;
        }
    }

  /*  void DoorClose()
        {
            closestdoor.GetComponent<Animator>().SetTrigger("Trigger Door");
        } */

        #region drawlines
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
            Gizmos.DrawWireSphere(transform.position, objRadius);
          /*  Gizmos.DrawWireSphere(transform.position, doorRadius); */
        }
        #endregion
    }

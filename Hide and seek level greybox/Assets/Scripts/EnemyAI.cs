using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public HidingSpot occupy;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Hiding").transform;
        GameObject g = GameObject.FindGameObjectWithTag("Hiding");
        occupy = g.GetComponent<HidingSpot>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hiding")
        {
            Destroy(gameObject, 1.0f);
            occupy.Occupied = true;

        }
    }
}

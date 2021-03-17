using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectivebar : MonoBehaviour
{
    public float objectivestarting = 0f;
    public float currentprogress;
    public float maxprogress = 100;
    public GameObject Objective;
    public Vector3 Done;

    // Start is called before the first frame update
    void Start()
    {
        currentprogress = objectivestarting;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentprogress >= maxprogress)
        {
        Objective.transform.position = Done;
        } 
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            InvokeRepeating("Objectivefill", 1.0f, 2.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CancelInvoke("Objectivefill");
        }
    }

    public void Objectivefill()
    {
        currentprogress += 10;
    }

}

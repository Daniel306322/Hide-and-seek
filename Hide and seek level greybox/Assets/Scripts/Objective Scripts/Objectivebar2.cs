using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectivebar2 : MonoBehaviour
{
    public float objectivestarting2 = 0f;
    public float currentprogress2;
    public float maxprogress2 = 100;
    public GameObject Objective2;
    public Vector3 Done2;

    // Start is called before the first frame update
    void Start()
    {
        currentprogress2 = objectivestarting2;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentprogress2 >= maxprogress2)
        {
        Objective2.transform.position = Done2;
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
            CancelInvoke("Objectivefill2");
        }
    }

    public void Objectivefill2()
    {
        currentprogress2 += 10;
    }

}

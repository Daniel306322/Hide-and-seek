using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public bool Occupied = false;
    public GameObject enemyPrefab;
    public Transform SpawnPosition;

    void Start()
    {
        
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (Occupied == false)
            {
                Occupied = true;
                Destroy(coll.gameObject);
            }
        }
       
        if (coll.gameObject.tag == "Player")
        {
            if (Occupied == true)
            {
               StartCoroutine(Found());
            }
        }
    }


    IEnumerator Found()
    {
        Instantiate(enemyPrefab, SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        yield return new WaitForSeconds(3f);
        Occupied = false;
    }


}
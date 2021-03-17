using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotFound : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HidingSpotprefab;
    public Transform Self;

    void Start()
    {

    }


    void Update()
    {
        //add radius and spawn enemy only when player is outside radius
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine(Found());
        }
    }


    IEnumerator Found()
    {
        Instantiate(enemyPrefab, Self.transform.position, Self.transform.rotation);
        yield return new WaitForSeconds(5f);
        Instantiate(HidingSpotprefab, Self.transform.position, Self.transform.rotation);
        Destroy(gameObject);
    }
}
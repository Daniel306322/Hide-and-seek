using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public GameObject HidingSpotFoundprefab;
    public Transform Self;

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
            StartCoroutine(Hiding());
        }

        IEnumerator Hiding()
        {
            Destroy(coll.gameObject);
            Instantiate(HidingSpotFoundprefab, Self.transform.position, Self.transform.rotation);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
            yield return new WaitForSeconds(1f);
        }
    }
}
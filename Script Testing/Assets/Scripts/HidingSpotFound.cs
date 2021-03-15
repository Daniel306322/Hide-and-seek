using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotFound : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HidingSpotprefab;
    public Transform Self;
    public float playergoneRadius = 50f;
    Transform player;

    void Start()
    {
        player = PlayerManager.instance.Player.transform;
        InvokeRepeating("Check", 1.0f, 2.0f);
    }


    void Update()
    {

    }

    private void Check()
    {
        float playerdistance = Vector3.Distance(player.position, transform.position);
        //add radius and spawn enemy only when player is outside radius
        if (playerdistance > playergoneRadius)
        {
            StartCoroutine(Found());
            CancelInvoke("Check");
        }
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

    #region drawlines
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playergoneRadius);
    }
    #endregion

}
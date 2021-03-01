using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerRedHallway: MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject GunEnemyPrefab;
    public Transform SpawnPosition;
    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;
    public Transform SpawnPosition4;
    public Transform SpawnPosition5;
    public Transform SpawnPosition6;
    public Transform SpawnPosition7;
    public Transform SpawnPosition8;
    public bool SpawnedRed = false;
    public GameObject otherDoor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(SpawnedRed == false)
            {
                SpawnedRed = true;
                Invoke("SpawnEnemy", 1.0f);
                otherDoor.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition1.transform.position, SpawnPosition1.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition2.transform.position, SpawnPosition2.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition3.transform.position, SpawnPosition3.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition4.transform.position, SpawnPosition4.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition5.transform.position, SpawnPosition5.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition6.transform.position, SpawnPosition6.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition7.transform.position, SpawnPosition7.transform.rotation);
        Instantiate(GunEnemyPrefab, SpawnPosition8.transform.position, SpawnPosition8.transform.rotation);
        Destroy(gameObject);
    }
}

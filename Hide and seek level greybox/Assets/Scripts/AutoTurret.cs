using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{

    private GameObject target;
    public GameObject bullet;
    public GameObject bulletSpawnPoint; 
    private bool targetLocked;
    private bool shotReady;

    public GameObject Turret;
    public float fireTimer; 

    void Start()
    {
        shotReady = true; 
    }

    void Update()
    {
        if (targetLocked)
        {
            Turret.transform.LookAt(target.transform);

            if (shotReady)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

IEnumerator FireRate()
        {
            yield return new WaitForSeconds(fireTimer);
            shotReady = true;
        }   

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (target)
                targetLocked = true;
            else
                targetLocked = false;

            if (targetLocked == false)
            {
                target = other.gameObject; 
            }

        }
    }
}

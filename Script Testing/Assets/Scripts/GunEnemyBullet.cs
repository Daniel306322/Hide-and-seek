using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    private GameObject target;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        Invoke("DestroySelf", 3.0f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

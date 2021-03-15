using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;
    public Transform bulletSpawnPoint4;
    public Transform bulletSpawnPoint5;
    public int currentAmmo;
    public float reloadTime = 0.01f;
    public int maxAmmo = 6;
    private bool isReloading = false;
    public Text ammoText;
    public bool canShoot;
    public float fireTimer = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        ammoText.text = "Ammo: " + currentAmmo;

            if (Input.GetMouseButtonDown(0))
            {
            if (canShoot == true)
            {
                Shoot();
            }
            }
            if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
            if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(1);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint1.transform.position, bulletSpawnPoint1.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint2.transform.position, bulletSpawnPoint2.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint3.transform.position, bulletSpawnPoint3.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint4.transform.position, bulletSpawnPoint4.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawnPoint5.transform.position, bulletSpawnPoint5.transform.rotation);
        currentAmmo--;
        canShoot = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        canShoot = true;
    }
}



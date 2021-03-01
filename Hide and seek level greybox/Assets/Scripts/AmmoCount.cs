using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public int currentAmmo;
    public float reloadTime = 10f;
    public int maxAmmo = 10;
    private bool isReloading = false;
    public Text ammoText;


    void Start()
    {
        currentAmmo = maxAmmo;
    }


    void Update()
    {
        ammoText.text = "Ammo:" + currentAmmo;
        if (isReloading)
            return;
        

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }
    IEnumerator Reload()
    {
        isReloading =  true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

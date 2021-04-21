using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ontriggersound : MonoBehaviour
{
    public AudioSource sound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            sound.Play();
        }
    }

}

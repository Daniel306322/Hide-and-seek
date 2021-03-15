using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDead : MonoBehaviour
{
    public Vector3 SpawnPoint;

    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player")
        {
            col.transform.position = SpawnPoint;
        }
    }

}

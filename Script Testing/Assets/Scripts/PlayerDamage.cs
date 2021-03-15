using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public bool damageReady;
    public bool CheckpointEnter = false;
    public Vector3 SpawnPoint;
    public GameObject Player;
    public GameObject Door;

    void Start()
    {

    }

     void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            if (CheckpointEnter == true)
                {
                CheckpointEnter = false;
                Player.transform.position = SpawnPoint;
                }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            if (CheckpointEnter == false)
            {
                CheckpointEnter = true;
            }
        }
    }

     private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DoorTrigger")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Door.GetComponent<Animator>().SetTrigger("Trigger Door");
            }
        }
    } 

}

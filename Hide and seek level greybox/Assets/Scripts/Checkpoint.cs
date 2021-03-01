using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool CheckpointEnter = false;

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            if (CheckpointEnter == false)
            {
                CheckpointEnter = true;
            }
        }
    }


}

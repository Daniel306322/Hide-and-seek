using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion 

    public GameObject Player;
    public GameObject Hiding;
    public GameObject Objective;
    public GameObject Objective1;
    public GameObject Objective2;
    public GameObject Door;
    public float Enemiesdead;
    public float objectivesdone;

    void Start()
    {
        Enemiesdead = 0f;
    }

    void Update()
    {
        if (Enemiesdead == 5)
        {
            //increase ai speed higher
        }

        if (Enemiesdead == 10)
        {
            //player wins
        }

        if (objectivesdone == 10)
        {
            //player loses
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool damageReady;
    public bool CheckpointEnter = true;
    public GameObject playerprefab;
    public Vector3 SpawnPoint;
    public GameObject objectToMove;
    public GameObject shield;
    public GameObject attack;
    public GameObject sword;
  
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        damageReady = true;
    }

     void Update()
    {
        if (currentHealth <= 0)
        {
            if (CheckpointEnter == false)
            {
                playerprefab.transform.position = SpawnPoint;
                TakeDamage(-maxHealth);
                StartCoroutine(Reset());
            }
        }

        if (Input.GetKey(KeyCode.Y))
        {
            if (CheckpointEnter == false)
            {
                StartCoroutine(Reset());
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            objectToMove.GetComponent<Animator>().SetTrigger("Swing");
            Invoke("Attack", 1.0f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            shield.GetComponent<Animator>().SetTrigger("Shove");
        }


    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            if (CheckpointEnter == true)
            {
                CheckpointEnter = false;
            }
        }
    }

    void Attack()
    {
        Instantiate(attack, sword.transform.position, sword.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (damageReady == true)
            {
                StartCoroutine(Hit());
                
            }

        }
        
        if (collision.gameObject.tag == "Heal")
        {
            StartCoroutine(Healing());
        }
    }

    IEnumerator Hit()
    {
        damageReady = false;
        yield return new WaitForSeconds(0.5f);
        TakeDamage(10);
    }

    IEnumerator Healing()
    {
        yield return new WaitForSeconds(0.5f);
        TakeDamage(-30);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        damageReady = true;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        playerprefab.transform.position = SpawnPoint;
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        CheckpointEnter = true;
    }

}
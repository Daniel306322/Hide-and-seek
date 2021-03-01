using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 300.0f;
    public bool canJump;
    public float jumpTimer = 1f;
    public float speed = 0.1f;
    void Start()
    {
        canJump = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (transform.forward * -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (transform.right * -speed);
        }

        if (Input.GetKeyDown("space"))
        {
            if (canJump == true) 
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        canJump = false;
        StartCoroutine(JumpWait());
    }

    IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(jumpTimer);
        canJump = true;
    }

}

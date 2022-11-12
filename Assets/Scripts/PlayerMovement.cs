using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool jumpInput;
    private bool isGrounded;
    private float horizontalInput;
    private Rigidbody rb;
    private float KillBoxTrigger;
    public GameObject sprite;

    public GameObject KillBox;
    public bool KillBoxRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        KillBoxTrigger = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            jumpInput = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            KillBoxRight = true;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            KillBoxRight = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 2, ForceMode.VelocityChange);
        rb.velocity = new Vector3(horizontalInput * 15, rb.velocity.y, 0);

        if (!isGrounded)
        {
            return;
        }
        
        if (jumpInput)
        {
            rb.AddForce(Vector3.up * 60, ForceMode.VelocityChange);
            jumpInput = false;
        }


        if (KillBoxRight & KillBoxTrigger >= 1)
        {
            KillBox.transform.position = KillBox.transform.position + new Vector3(-4f, 0, 0);
            KillBoxTrigger --;
        }

        if (!KillBoxRight & KillBoxTrigger <= 0)
        {
            KillBox.transform.position = KillBox.transform.position + new Vector3(+4f, 0, 0);
            KillBoxTrigger ++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

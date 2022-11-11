using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool jumpInput;
    private bool isGrounded;
    private float horizontalInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            jumpInput = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

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

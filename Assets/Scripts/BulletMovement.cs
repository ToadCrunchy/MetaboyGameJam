using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float Speed = 2f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

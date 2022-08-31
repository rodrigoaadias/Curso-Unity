using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float jumpPower = 10;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 velocity = rb.velocity;
        velocity.x = speed * x;

        if(Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpPower;
        }

        rb.velocity = velocity;
    }
}

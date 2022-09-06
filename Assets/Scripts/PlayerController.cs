using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpPower = 10;
    [SerializeField] GameObject bulletPrefab;

    Rigidbody2D rb;
    Animator animator;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();

        Vector2 velocity = rb.velocity;
        velocity.x = GetSpeed();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpPower;
        }

        rb.velocity = velocity;

        UpdateAnimator();
        UpdateDirection();

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void CheckGround()
    {
       isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.1f, 0.1f, groundMask);
    }

    private float GetSpeed()
    {
        float x = Input.GetAxisRaw("Horizontal");
        return speed * x;
    }

    private void UpdateDirection()
    {
        float currentSpeed = GetSpeed();

        if (currentSpeed == 0)
        {
            return;
        }

        if(currentSpeed > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", Mathf.Abs(GetSpeed()));
        animator.SetFloat("Vertical Speed", rb.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void Shoot()
    {
        // tocar animação
        animator.SetTrigger("Shoot");

        // disparar
        Instantiate(bulletPrefab, transform);
    }
}

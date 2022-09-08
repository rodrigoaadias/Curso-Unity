using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IDamage
{
    [SerializeField] float speed;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float health = 30f;
    [SerializeField] float damage = 10f;


    private void Update()
    {
        transform.position += Vector3.right * transform.localScale.x * speed * Time.deltaTime;

        CheckEdge();
    }

    private void CheckEdge()
    {
        Vector3 center = transform.position + Vector3.right * transform.localScale.x;

        if(!Physics2D.OverlapCircle(center, 0.1f, groundMask))
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    public void Damage(float points)
    {
        health -= points;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IDamage damage = collision.GetComponent<IDamage>();
            damage.Damage(this.damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxDuration = 5f;
    [SerializeField] float damage = 10f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = Vector2.right * transform.parent.localScale.x * speed;
        transform.parent = null;

        Destroy(gameObject, maxDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") return;

        // se for inimigo, causar dano
        if(collision.TryGetComponent(out IDamage damage))
        {
            damage.Damage(this.damage);
        }

        Destroy(gameObject);
    }
}

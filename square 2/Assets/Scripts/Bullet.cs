using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float size;
    public float piercingDamage;
    public float piercingHealth;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (piercingHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            collision.gameObject.GetComponent<EnemyBullet>().piercingHealth -= piercingDamage;
        }
    }
}

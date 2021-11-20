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
    public float lifetime = 20f;
    public int enemyPiercing;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }

        if (piercingHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (enemyPiercing <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            collision.gameObject.GetComponent<EnemyBullet>().piercingHealth -= piercingDamage;
            collision.gameObject.GetComponent<EnemyBullet>().piercingHealth -= piercingDamage;
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<TakeDamage>().takeDamage(damage);
            enemyPiercing--;
        }
    }
}

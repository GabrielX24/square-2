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

    private void Awake()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        rb.AddForce(new Vector3(worldPosition.x, worldPosition.y, 0f).normalized * speed);
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
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Bullet>().piercingHealth -= piercingDamage;
        }
    }
}

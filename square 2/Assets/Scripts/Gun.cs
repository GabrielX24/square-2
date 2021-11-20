using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public float clipSize;
    public float bulletsLeft;
    public float spread;
    public int bullets;
    public float reloadTime;
    private float bulletSize;
    public GameObject selectedBullet;
    public Bullet bulletScript;
    public Camera cam;
    public SpriteRenderer spriteRenderer;

    private float nextTimeToFire;
    public bool isReloading;
    public bool isFlipped;

    Vector2 mousePos;

    private void Awake()
    {
        bulletSize = bulletScript.size;
        cam = FindObjectOfType<Camera>();
        bulletsLeft = clipSize;
    }
    public void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (isReloading == false)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        Debug.Log(transform.eulerAngles.z);

        if (!isFlipped)
        {
            if (transform.eulerAngles.z >= 90 || transform.eulerAngles.z <= 270)
            {
                Flip();
                isFlipped = true;
            }
        }

        if (isFlipped)
        {
            if (transform.eulerAngles.z < 90 || transform.eulerAngles.z > 270)
            {
                Flip();
                isFlipped = false;
            }
        }
    }

    public void Flip()
    {
        if (isFlipped)
        {
            spriteRenderer.flipY = false;
        }
        else if (!isFlipped)
        {
            spriteRenderer.flipY = true;
        }

    }
    public void Shoot()
    {
        for (int i = 0; i < bullets; i++)
        {
            GameObject bullet = Instantiate(selectedBullet, transform.position, transform.rotation);
            bullet.transform.Rotate(new Vector3(0, 0, Random.Range(-spread, spread)));
        }

        bulletsLeft -= bulletSize;

        if (bulletsLeft <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        bulletsLeft = clipSize;

        isReloading = false;
    }
}

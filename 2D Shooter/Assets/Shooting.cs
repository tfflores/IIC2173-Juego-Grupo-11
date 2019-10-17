using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    

    // Update is called once per frame
    void Update()
    {
        var fireRate = .3f;

        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Shoot", .001f, fireRate);
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

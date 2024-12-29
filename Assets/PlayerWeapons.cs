using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    bool melee = false;
    public Transform weapons;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;

    public Transform firePoint;
    public GameObject projectile;
    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        melee = false;
    }

    // Update is called once per frame
    void Update()
    {
        weapons.position = transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }

    void Attack()
    {
        if (!melee)
        {
            //shoot bullet
            GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();

            bulletrb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else { 
            //swing sword
        }
    }
}

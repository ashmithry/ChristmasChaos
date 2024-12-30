using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    bool melee = false;
    public Transform weapons;

    public GameObject ranged;
    public GameObject sword;

    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;

    public Transform firePoint;
    public GameObject projectile;
    public float bulletForce = 20f;
    private float rtimeBtwAttack;
    public float rstartTimeBtwAttack = 0.5f;

    [Header("Melee System")]
    private float mtimeBtwAttack;
    public float mstartTimeBtwAttack = 0.3f;
    public float meleeDmg;
    public Animator anim;

    public Transform attackPos;
    public LayerMask enemyLayer;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        melee = false;
        if (melee)
        {
            ranged.SetActive(false);
            sword.SetActive(true);
        }
        else
        {
            ranged.SetActive(true);
            sword.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        weapons.position = transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



        if (rtimeBtwAttack <= 0 && !melee)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                rtimeBtwAttack = rstartTimeBtwAttack;
            }
        }
        else { 
            rtimeBtwAttack -= Time.deltaTime;
        }


        if (mtimeBtwAttack <= 0 && melee)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                mtimeBtwAttack = mstartTimeBtwAttack;
            }
        }
        else
        {
            mtimeBtwAttack -= Time.deltaTime;
        }





        if (Input.GetKeyDown(KeyCode.E))
        {
            melee = !melee;
            if (melee)
            {
                ranged.SetActive(false);
                sword.SetActive(true);
            }
            else
            {
                ranged.SetActive(true);
                sword.SetActive(false);
            }
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
            anim.SetTrigger("Slash");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
            foreach (Collider2D col in enemiesToDamage)
            {
                col.GetComponent<Enemy>().takeDamage(meleeDmg);
                col.GetComponent<AIChase>().Knockback(1f);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage;
    public float lifetime;

    public GameObject destroyFX;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
        Invoke("DestroySelf", lifetime);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        { 
            //damage enemy here
            col.gameObject.GetComponent<Enemy>().takeDamage(damage);
            DestroySelf();
        }
    }

    void DestroySelf()
    { 
        Instantiate(destroyFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

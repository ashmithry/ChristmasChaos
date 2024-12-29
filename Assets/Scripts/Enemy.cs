using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }
    public void takeDamage(float damageAmount)
    {
        health -= damageAmount;

        if( health <= 0)
        {
            EndSelf();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.name.Contains("Projectile"))
        {
            EndSelf();
        }
        
    }

    public void EndSelf()
    {
        GameObject.Find("Score").GetComponent<Score>().EnemyKilled();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health/maxHealth;
    }
}

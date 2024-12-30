using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    public Transform sprite;

    [Header("Health")]
    public float health;
    public float maxHealth;

    public GameObject heart;
    public GameObject dieFX;
    public Transform heartArr;
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xmov = Input.GetAxisRaw("Horizontal");
        float ymov = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(xmov, ymov) * moveSpeed;

        if (xmov < 0)
        {
            sprite.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else if (xmov > 0){
            sprite.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            // Destroy player
            endScreen.SetActive(true);
            LeanTween.scale(endScreen, new Vector3(1f, 1f, 1), 0.1f).setEase(LeanTweenType.easeInExpo);
            Time.timeScale = 0;
            Instantiate(dieFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // Adjust hearts
        Transform[] hearts = heartArr.GetComponentsInChildren<Transform>();

        for (int i = hearts.Length - 1; i > hearts.Length - Damage - 1; i--)
        {
            Debug.Log(hearts[i].name);
            Destroy(hearts[i].gameObject);
        }
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}

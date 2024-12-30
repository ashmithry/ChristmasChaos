using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    public Rigidbody2D rb;
    Vector3 direction;

    public float timeInKnockback;

    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Present");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        if (timeInKnockback <= 0)
        {
            rb.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
        }
        else
        { 
            timeInKnockback -= Time.deltaTime;
        }
    }

    public void Knockback(float k)
    {
        timeInKnockback = k;

        Vector3 dir = (transform.position - player.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(dir * 2f, ForceMode2D.Impulse);
    }
}

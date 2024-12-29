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
    public Transform heartArr;

    // Start is called before the first frame update
    void Start()
    {
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
}

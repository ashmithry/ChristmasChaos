using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist=Vector2.Distance(transform.position,player.transform.position);
        Vector2 direction = player.transform.position - transform.forward;
        //direction.Normalize();
       // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle); 
    }
}

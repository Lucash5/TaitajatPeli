using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviourScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float damage;
    public float health;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
       
        
        transform.right = direction * -1;

        rb.velocity = direction * -1;
       
    }

    public void takingdamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

  

}

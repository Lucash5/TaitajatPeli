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
    bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Koodi joka vastaa zombin käännöksestä ja liikkumisesta valittuuun suuntaan
        Vector2 direction = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
       
        
        transform.right = direction * -1;

        rb.velocity = direction * -1;
       
    }

    public void takingdamage(float damage)
    {
        // koodi joka vastaa vahingon rekisteröimisestä zombiin
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            player.gameObject.GetComponent<PointsScript>().addpoints(50);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // koodi joka vastaa zombin aiheuttamasta vahingosta pelaajaan
        if (collision.gameObject.name == "Player" && cooldown == false)
            StartCoroutine(attackcooldown());
        {
            collision.gameObject.GetComponent<PlayerMovement>().takedamage(damage);
        }
    }


    IEnumerator attackcooldown()
    {
        // koodi joka vastaa viiveen luo9misesta ettei zombie voi lyödä tuhat kertaa sekunnisssa
        cooldown = true;
        yield return new WaitForSeconds(1);
        cooldown = false;
    }

}

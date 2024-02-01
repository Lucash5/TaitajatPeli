using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletdamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieBehaviourScript>().takingdamage(bulletdamage);
            Destroy(gameObject);
        }
    }
}

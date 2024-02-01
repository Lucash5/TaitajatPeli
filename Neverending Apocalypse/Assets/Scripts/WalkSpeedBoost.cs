using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            float speed = collision.gameObject.GetComponent<PlayerMovement>().speed;
            collision.gameObject.GetComponentInChildren<PlayerMovement>().changedamage(speed + speed * 0.5f, 30f);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGBoostScript : MonoBehaviour
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
            float dmg = collision.gameObject.GetComponentInChildren<GunScript>().bulletdamage;
            collision.gameObject.GetComponentInChildren<GunScript>().changedamage(dmg + dmg*0.5f, 30f);
            Destroy(gameObject);
        }
    }
}

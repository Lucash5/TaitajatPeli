using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    bool cooldown;
    public GameObject bullet;
    public float bulletspeed;
    public float bulletdamage;
    public float firerate;
    public Transform bulletsfolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldown == false)
        {
            StartCoroutine(firingbullet());
        }
    }

    IEnumerator firingbullet()
    {
        cooldown = true;
        GameObject createdbullet = Instantiate(bullet);
        createdbullet.transform.position = transform.position;
        createdbullet.transform.rotation = transform.rotation;
        createdbullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed);
        createdbullet.GetComponent<BulletScript>().bulletdamage = bulletdamage;
        yield return new WaitForSeconds(firerate);
        cooldown = false;
        yield return new WaitForSeconds(4);
        if (createdbullet != null)
        {
            Destroy(createdbullet);
        }

    }

    public void changedamage(float damage)
    {
        bulletdamage = damage;
    }

    public void changefirerate(float rate)
    {
        firerate = rate;
    }
}

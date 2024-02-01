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
    public Sprite[] guns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldown == false)
        {
            // koodi joka kutsuu Ienumeraatto9rin kun hiiren n‰pp‰int‰ painetaan
            StartCoroutine(firingbullet());
        }
    }

    IEnumerator firingbullet()
    {
        // Koodi joka luo luodin ja luo siihen voimaa
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

    public void changedamage(float damage, float time)
    {
        //koodi joka vaihtaa luodin vahinkomÂ‰‰r‰‰‰
        StartCoroutine(timesup(time));
        bulletdamage = damage;
    }
    public void changeweapondamage(float damage)
    {
        bulletdamage = damage;
    }
    IEnumerator timesup(float time)
    {
        //koodi joka vastaa power uppien loppumisesta
        float olddmg = bulletdamage;
        yield return new WaitForSeconds(time);
        bulletdamage = olddmg;
    }
    public void changefirerate(float rate)
    {
        // koodi joka vaihtaa tulitusnopeutta
        firerate = rate;
    }
    public void changeweapon(string gun)
    {
        // koodi joka vastaa aseencaihtamiesta
        foreach (Sprite guntype in guns)
        {
            if (guntype.name == gun)
            {
                Debug.Log(guntype.name);
                gameObject.GetComponentInParent<SpriteRenderer>().sprite = guntype;
            }
        }
    }
}

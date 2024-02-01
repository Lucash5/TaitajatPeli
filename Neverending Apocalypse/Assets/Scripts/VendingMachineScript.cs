using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineScript : MonoBehaviour
{
   
    public Image shop;
    public Button[] guns;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        guns[0].onClick.AddListener(option1);
        guns[1].onClick.AddListener(option2);
        guns[2].onClick.AddListener(option3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            shop.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ui joka avataan ku7n pelaaja k‰velee masiinan luo
        if(collision.gameObject.name == "Player")
        {
            shop.gameObject.SetActive(false);
        }
    }
    // Kolme metodia joilla on kaikilla oma ase ja ominaisuutensa jotka l‰hetet‰‰n pelaajan aseen vaihtamiseksi
    private void option1()
    {
        
        if (player.GetComponent<PointsScript>().points >= 500)
        {

        player.GetComponent<PointsScript>().removepoints(500);
        player.GetComponentInChildren<GunScript>().changeweapon("PISTOL");
        player.GetComponentInChildren<GunScript>().changefirerate(0.3f);
        player.GetComponentInChildren<GunScript>().changeweapondamage(19f);

        }
    }
    private void option2()
    {
        if (player.GetComponent<PointsScript>().points >= 2250)
        {
            player.GetComponent<PointsScript>().removepoints(2250);
            player.GetComponentInChildren<GunScript>().changeweapon("AK47");
            player.GetComponentInChildren<GunScript>().changefirerate(0.1f);
            player.GetComponentInChildren<GunScript>().changeweapondamage(20f);
        }
    }
    private void option3()
    {
            if (player.GetComponent<PointsScript>().points >= 6000)
            {
                player.GetComponent<PointsScript>().removepoints(6000);
                player.GetComponentInChildren<GunScript>().changeweapon("LMG");
                player.GetComponentInChildren<GunScript>().changefirerate(0.075f);
                player.GetComponentInChildren<GunScript>().changeweapondamage(25f);
            }
    }
}

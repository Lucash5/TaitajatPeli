using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineScript : MonoBehaviour
{
    GameObject player;
    public Image shop;
    public Button[] guns;
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
            player = collision.gameObject;
            shop.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            shop.gameObject.SetActive(false);
        }
    }
    private void option1()
    {
        if (player.GetComponent<PointsScript>().points >= 500)
        {

        player.GetComponent<PointsScript>().removepoints(500);
        player.GetComponent<GunScript>().changeweapon("Pistol");
        player.GetComponent<GunScript>().changefirerate(0.3f);
        player.GetComponent<GunScript>().changeweapondamage(19f);

        }
    }
    private void option2()
    {
        if (player.GetComponent<PointsScript>().points >= 2250)
        {
            player.GetComponent<PointsScript>().removepoints(2250);
            player.GetComponent<GunScript>().changeweapon("AK47");
            player.GetComponent<GunScript>().changefirerate(0.1f);
            player.GetComponent<GunScript>().changeweapondamage(20f);
        }
    }
    private void option3()
    {
            if (player.GetComponent<PointsScript>().points >= 6000)
            {
                player.GetComponent<PointsScript>().removepoints(6000);
                player.GetComponent<GunScript>().changeweapon("LMG");
                player.GetComponent<GunScript>().changefirerate(0.05f);
                player.GetComponent<GunScript>().changeweapondamage(26f);
            }
    }
}

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
        player.GetComponent<PointsScript>().removepoints(500);
        player.GetComponent<GunScript>().changeweapon("Pistol");

    }
    private void option2()
    {
        player.GetComponent<PointsScript>().removepoints(2250);
        player.GetComponent<GunScript>().changeweapon("AK47");

    }
    private void option3()
    {
        player.GetComponent<PointsScript>().removepoints(6000);
        player.GetComponent<GunScript>().changeweapon("LMG");

    }
}

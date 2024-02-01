using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawnScript : MonoBehaviour
{
    public Transform player;
    public float spawnspeed;
    public float startspawnspeed;
    bool spawncooldown;
    public Transform[] spawnarea;
    public GameObject zombie;
    public float difficulty;
    public float health;
    public float damage;

    
    // Start is called before the first frame update
    void Start()
    {
        // aktivoidaaan Ienumeraattori 
        StartCoroutine(increase());
    }

    // Update is called once per frame
    void Update()
    {
        // koodi joka vastaa zombie spawnaamisesta. 
  
        if (spawncooldown == false)
        {
            StartCoroutine(spawnzombie());
        }
        health = 100 * difficulty;
        damage = 15 * difficulty;
        spawnspeed = startspawnspeed / difficulty;


        
    }

    IEnumerator spawnzombie()
    {
        //koodissa kloonataan zombi objekti ja kloonille annetaan arvoja
        spawncooldown = true;
        yield return new WaitForSeconds(spawnspeed);
        GameObject spawnedzombie =  Instantiate(zombie);
        spawnedzombie.transform.position = new Vector2(Random.Range(spawnarea[0].position.x, spawnarea[1].position.x), Random.Range(spawnarea[0].position.y, spawnarea[1].position.y));
        spawnedzombie.SetActive(true);
        spawnedzombie.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        spawnedzombie.name = "Zombie";
        spawnedzombie.GetComponent<ZombieBehaviourScript>().health = health;
        spawncooldown = false;
    }


    IEnumerator increase()
    {
        //spawnaus nopeus kiihtyy
        yield return new WaitForSeconds(90);
        startspawnspeed = 4;
        yield return new WaitForSeconds(90);
        startspawnspeed = 2;
    }
}

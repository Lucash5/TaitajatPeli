using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawnScript : MonoBehaviour
{
    public Transform player;
    public float spawnspeed;
    bool spawncooldown;
    public Transform[] spawnarea;
    public GameObject zombie;
    public float difficulty;
    public float health;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float number = MathF.Pow(player.position.x - transform.position.x, 2) + MathF.Pow(player.position.y - transform.position.y, 2);
        float distancefromplayer = MathF.Sqrt(number);
        if (spawncooldown == false && distancefromplayer < 20)
        {
            StartCoroutine(spawnzombie());
        }
        Debug.Log(distancefromplayer);
        health = 100 * difficulty;
        damage = 15 * difficulty;
        spawnspeed = 2 / difficulty;

      
    }

    IEnumerator spawnzombie()
    {
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
}

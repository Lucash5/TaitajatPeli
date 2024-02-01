using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    bool cooldown;
    public float points;
    public TMP_Text amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // kooid joka vastaa pelaajan pistem‰‰rist‰
        amount.text = "Points    " + points.ToString() + " / 20000";

        if (cooldown == false)
        {
            StartCoroutine(timeEqualsPoints());
        }

        if (points >= 20000)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void addpoints(float amount)
    {
        points += amount;
        //koodi lis‰‰ pisteit‰ pelaajalle
    }

    public void removepoints(float amount)
    { 
        // koodi poistaa pisteit‰ pelaajalta
        points -= amount;
    }

    IEnumerator timeEqualsPoints()
    {
        cooldown = true;
        points += 5;
        yield return new WaitForSeconds(1);
        cooldown = false;
        // koodi lis‰‰ koko ajan piene m‰‰r‰n pisteit‰ pelaajalle joka sekuntti
    }

}

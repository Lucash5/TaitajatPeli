using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        amount.text = "Points    " + points.ToString() + " / 20000";

        if (cooldown == false)
        {
            StartCoroutine(timeEqualsPoints());
        }
    }

    public void addpoints(float amount)
    {
        points += amount;
    }

    public void removepoints(float amount)
    { 
        points -= amount;
    }

    IEnumerator timeEqualsPoints()
    {
        cooldown = true;
        points += 5;
        yield return new WaitForSeconds(1);
        cooldown = false;
    }

}

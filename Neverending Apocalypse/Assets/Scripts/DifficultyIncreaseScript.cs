using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyIncreaseScript : MonoBehaviour
{
    float difficultymultiplier = 1;
    bool cooldown;
    public TMP_Text difficulty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        difficulty.text = "Difficulty Multiplier : " + difficultymultiplier.ToString() + "x";

        if ( cooldown  == false)
        {
            StartCoroutine(counting());
        }
    }

    IEnumerator counting()
    {
        cooldown = true;
        difficultymultiplier += 0.005f;
        yield return new WaitForSeconds(1);
        cooldown = false;
    }
}

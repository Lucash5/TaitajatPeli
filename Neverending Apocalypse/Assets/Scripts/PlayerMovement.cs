using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text Healthtext;
    //Rigidbody komponentti joka vastaa pelaajan fyysisest‰ liikkumisesta ja k‰ytt‰ytymisest‰
    Rigidbody2D rb;
    //Desimaaliluku muuttuja jota voi vaihdella editorissa ja joka vastaa pelaajan liikkumisnopeudesta
    public float speed;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        //Haetaan rigidbody2D komponentti pelaaja objektista ja nimet‰‰n se scriptiss‰ rb:ksi
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // kamera seuraa pelaajan positiota
        // hiiren positiolla lasketaan sijainti johon pelaaja katsoo
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction =  new Vector2(transform.position.x-mouseposition.x, transform.position.y-mouseposition.y);

        transform.right = direction * -1;


    }

    public void changedamage(float newspeed, float time)
    {
        StartCoroutine(timesup(time));
        speed = newspeed;
    }
    IEnumerator timesup(float time)
    {
        float oldspeed = speed;
        yield return new WaitForSeconds(time);
        speed = oldspeed;
    }

    public void takedamage(float damagetaken)
    {
        health -= damagetaken;
        Healthtext.text = "Health : " + health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

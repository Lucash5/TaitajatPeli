using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody komponentti joka vastaa pelaajan fyysisest‰ liikkumisesta ja k‰ytt‰ytymisest‰
    Rigidbody2D rb;
    //Desimaaliluku muuttuja jota voi vaihdella editorissa ja joka vastaa pelaajan liikkumisnopeudesta
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Haetaan rigidbody2D komponentti pelaaja objektista ja nimet‰‰n se scriptiss‰ rb:ksi
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction =  new Vector2(transform.position.x-mouseposition.x, transform.position.y-mouseposition.y);

        transform.right = direction * -1;


    }
}

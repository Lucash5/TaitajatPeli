using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndScreenScript : MonoBehaviour
{
    //Nappi
    public Button BUTTON;
    // Start is called before the first frame update
    void Start()
    {
        //Lis‰t‰‰n nappiin kuuntelija
        BUTTON.onClick.AddListener(loading);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void loading()
    {

        // nappia kun painetaan se vie ko0mentoon joka lataa uuden scenen
        SceneManager.LoadScene("Map");
    }

   
}

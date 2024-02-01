using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //nappi
    public Button BUTTON;
    // Start is called before the first frame update
    void Start()
    {
        BUTTON.onClick.AddListener(loading);
        //lis‰t‰‰n nappiin kuuntelija
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void loading()
    { 
        // nappia kun painetaan niin lataa uuden scenen nimelt‰ map0

    SceneManager.LoadScene("Map");
}
        
}

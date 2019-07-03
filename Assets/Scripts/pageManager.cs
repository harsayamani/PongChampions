using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pageManager : MonoBehaviour
{
    public bool isEscapeToExit;

    public void playGame()
    {
        SceneManager.LoadScene("main");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                backToMenu();
            }
        }
    }
}

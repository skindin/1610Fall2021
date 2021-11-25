using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager main;

    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (main == null)
            main = this;
    }

    public void Play ()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
    }

    public void GameOver ()
    {
        gameOverMenu.SetActive(true);
    }

    // Update is called once per frame
}

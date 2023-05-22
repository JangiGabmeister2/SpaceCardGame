using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static MenuHandler;

public class MenuHandler : MonoBehaviour
{
    //Singleton class
    public static MenuHandler instance { get; private set; }


    #region variables and Enum

    public GameObject[] panels;

    public enum MenuStates
    {
        JoinGame,
        HostGame,
        DeckBuilder,
        Options,
        QuitGame,
        Pause
    }

    public MenuStates menuState;

    #endregion

    private void Awake()
    {
        //If the instance doesnt exist, then this is the instance, otherwise destroy the imposter!
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CloseAllPanels();
    }

    #region Button Functions
    public void JoinGame()
    {
        // Join a server
        ChangeScene("Gameplay");
    }

    public void HostGame()
    {
        //Host a server
        ChangeScene("GamePlay");
    }

    /*public void DeckBuilder()
    {
        // Go to build deck.
    }

    public void OptionsMenu()
    {
        //Go to options Menu
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region Panel Functions

    public void CloseAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            //Set all Panels to false
            panels[i].SetActive(false);
        }
    }

    public void ChangePanel(int value)
    {
        menuState = (MenuStates)value;


        switch (menuState)
        {


            case MenuStates.JoinGame:

                //Close all active panels, then active the Join Game panel.
                CloseAllPanels();
                panels[0].SetActive(true);

                //if Connection is made:
                //JoinGame();
                //CloseAllPanels();

                break;
            case MenuStates.HostGame:

                //Close all active panels, then active the Host Game panel.
                CloseAllPanels();
                panels[1].SetActive(true);

                //if Connection is made:
                //HostGame();
                //CloseAllPanels();


                break;

            case MenuStates.DeckBuilder:


                CloseAllPanels();
                //Close all active panels, then active the DeckBuilder panel.
                panels[2].SetActive(true);

                break;

            case MenuStates.Options:


                CloseAllPanels();
                //Close all active panels, then active the DeckBuilder panel.
                panels[3].SetActive(true);

                break;


            default:
                //Display only the main Menu
                CloseAllPanels();

                break;
        }
    }


    #endregion

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        CloseAllPanels();

    }

    public void MainMenuOptionsBackButton()
    {
        //Save prefs?
        CloseAllPanels();
    }

    public void DeckBuilderConfirmButton()
    {
        //Save deck
        CloseAllPanels();
    }



}

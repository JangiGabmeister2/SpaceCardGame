using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static MenuHandler;

public class MenuHandler : MonoBehaviour
{
    //Singleton class
    public static MenuHandler instance { get; private set; }
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

        CloseAllPanels();

    }

    #region variables and Enum

    public GameObject[] panels;
    public Button pauseButton;
    public Button returnToGame;
    public Button returnToMenu;

    public GameObject gameplayUI;
    public GameObject overlay;



    public bool playerOneTurn;
    public bool playerTwoTurn;
    public bool isInGame;
    Timer timerClass;

    public enum MenuStates
    {
        MainMenu,
        JoinGame,
        HostGame,
        DeckBuilder,
        Options,
        Gameplay,
        Pause,
        EndGame
    }


    public MenuStates menuState;

    #endregion



    private void Start()
    {
        CloseAllPanels();
        if (menuState == MenuStates.MainMenu)
        {
            ChangePanel(0);
        }

        pauseButton.gameObject.SetActive(false);
        returnToGame.gameObject.SetActive(false);
        gameplayUI.gameObject.SetActive(false);
        timerClass = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CoinToss();
        }
    }

    #region Button Functions
    public void JoinGame()
    {
        // Join a server
        CloseAllPanels();
        //MenuStates menuState = MenuStates.GamePlay;
        ChangeScene("Gameplay");
    }

    public void HostGame()
    {
        //Host a server
        CloseAllPanels();
        //MenuStates menuState = MenuStates.GamePlay;
        ChangeScene("Gameplay");
    }

    /*public void DeckBuilder()
    {
        // Go to build deck.
    }

    public void OptionsMenu()
    {
        //Go to options Menu
    }*/
    public void MainMenuOptionsBackButton()
    {
        //Save prefs?
        CloseAllPanels();
        panels[0].SetActive(true);
    }

    public void DeckBuilderConfirmButton()
    {
        //Save deck
        CloseAllPanels();
        panels[0].SetActive(true);
    }

    public void EndTurn()
    {
        //Change to enemy turn
        timerClass.turnTimer = 15;

        Debug.Log("Enemy turn now");
    }
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

    public void ForfeitGame()
    {
        //Concede or Morale = 0
        gameplayUI.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
        CloseAllPanels();
        panels[7].SetActive(true);
    }

    public void WinGame()
    {
        gameplayUI.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
        CloseAllPanels();
        panels[6].SetActive(true);
    }

    public void ChangePanel(int value)
    {
        //When applying Change Panel to a button, int value refers to enum index.
        menuState = (MenuStates)value;

        switch (menuState)
        {
            case MenuStates.MainMenu:

                gameplayUI.gameObject.SetActive(false);
                overlay.gameObject.SetActive(false);
                CloseAllPanels();
                panels[0].SetActive(true);
                isInGame = false;
                break;

            case MenuStates.JoinGame:

                //Close all active panels, then active the Join Game panel.
                CloseAllPanels();
                //panels[0].SetActive(true); May not need a panel

                //if Connection is made:
                //JoinGame();
                //CloseAllPanels();

                break;
            case MenuStates.HostGame:

                //Close all active panels, then active the Host Game panel.
                CloseAllPanels();
                //panels[1].SetActive(true); May not need a panel

                //if Connection is made:
                //HostGame();
                //CloseAllPanels();


                break;

            case MenuStates.DeckBuilder:


                CloseAllPanels();
                //Close all active panels, then active the DeckBuilder panel.
                panels[3].SetActive(true);

                break;

            case MenuStates.Options:

                pauseButton.gameObject.SetActive(false);
                CloseAllPanels();
                //Close all active panels, then active the DeckBuilder panel.
                panels[4].SetActive(true);

                if (isInGame)
                {
                    returnToGame.gameObject.SetActive(true);
                    returnToMenu.gameObject.SetActive(false);

                }

                break;

            case MenuStates.Gameplay:
                CloseAllPanels();
                pauseButton.gameObject.SetActive(true);
                isInGame = true;
                gameplayUI.gameObject.SetActive(true);
                overlay.gameObject.SetActive(true);
                timerClass.timerOn = true;

                break;

            case MenuStates.Pause:
                CloseAllPanels();
                panels[5].SetActive(true);
                pauseButton.gameObject.SetActive(false);
                overlay.gameObject.SetActive(false);

                break;

            case MenuStates.EndGame:

                break;


            default:
                //Display only the main Menu
                Debug.Log("Something went wrong");

                break;
        }
    }


    #endregion

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        CloseAllPanels();

    }

    private void CoinToss()
    {
        int coinToss = Random.Range(0, 100);

        if (coinToss <= 50)
        {
            playerOneTurn = true;
            playerTwoTurn = false;

            Debug.Log("player one turn");
        }
        else
        {
            playerOneTurn = false;
            playerTwoTurn = true;
            Debug.Log("player two turn");
        }

        Debug.Log(coinToss);
    }




}



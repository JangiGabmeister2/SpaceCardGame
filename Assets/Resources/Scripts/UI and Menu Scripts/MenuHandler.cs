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
    public Button endTurnButton;
    public Button returnToGame;
    public Button returnToMenu;

    public GameObject gameplayUI;
    public GameObject overlay;
    public GameObject optionsUI;

    public bool isInGame;
    Timer timerClass;
    GameplayStateMachine gameplayStateMachineClass;

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
        gameplayStateMachineClass = FindObjectOfType<GameplayStateMachine>();
    }

    private void Update()
    {
        //Testing Purpose Only
        if (Input.GetKeyDown(KeyCode.L))
        {
            WinGame();
        }
    }

    #region Button Functions
    public void JoinGame()
    {
        // Join a server
        CloseAllPanels();
        //menuState = MenuStates.JoinGame;

        ChangeScene("Gameplay");
    }

    public void HostGame()
    {
        //Host a server
        CloseAllPanels();
        //menuState = MenuStates.HostGame;
        ChangeScene("Gameplay");
    }
    public void MainMenuOptionsBackButton()
    {
        //Save prefs?
        CloseAllPanels();
        panels[0].SetActive(true);
    }

    //This button goes back to main menu and is supposed to save the deck.
    public void DeckBuilderConfirmButton()
    {
        //Save deck
        CloseAllPanels();
        panels[0].SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    #endregion

    #region Panel Functions

    //This function closes all panels in the panel array when navigating other panels.
    //Usually declared first, followed by making the specific panel active that you are viewing.
    public void CloseAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            //Set all Panels to false
            panels[i].SetActive(false);
        }
    }
    
    //same as above, but with an exception of a specific panel
    public void CloseAllPanels(int exception)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        
        //leaves specific panel active
        panels[exception].SetActive(true);
    }

    //Sets the UI and overlay as false so that nothing can be clicked once the game is lost.
    //This function also will double for 'losing the game' 
    public void ForfeitGame()
    {
        //Concede or Morale = 0
        gameplayStateMachineClass.gameplayState = GameplayStateMachine.GameplayState.Lose;
        gameplayUI.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
        CloseAllPanels();
        panels[7].SetActive(true);

    }

    public void WinGame()
    {
        gameplayStateMachineClass.gameplayState = GameplayStateMachine.GameplayState.Win;
        gameplayUI.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
        CloseAllPanels();
        panels[6].SetActive(true);
    }

    //Change panel wording is possibly unclear, this function allows button presses to assign a switch to a particular state.
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


                break;
            case MenuStates.HostGame:

                //Close all active panels, then active the Host Game panel.
                CloseAllPanels();
                //panels[1].SetActive(true); May not need a panel

                //if Connection is made:
                //HostGame();



                break;

            case MenuStates.DeckBuilder:


                CloseAllPanels();
                //Close all active panels, then active the DeckBuilder panel.
                panels[3].SetActive(true);

                break;

            case MenuStates.Options:

                pauseButton.gameObject.SetActive(false);
                CloseAllPanels();
                optionsUI.SetActive(true);
                panels[4].SetActive(true);

                if (isInGame)
                {
                    returnToGame.gameObject.SetActive(true);
                    returnToMenu.gameObject.SetActive(false);

                }

                break;

            case MenuStates.Gameplay:
                CloseAllPanels(5);
                pauseButton.gameObject.SetActive(true);
                pauseButton.interactable = true;
                endTurnButton.interactable = true;
                isInGame = true;    
                gameplayUI.gameObject.SetActive(true);
                overlay.gameObject.SetActive(true);
                timerClass.timerOn = true;
                gameplayStateMachineClass.gameplayState = GameplayStateMachine.GameplayState.GameStart;

                break;

            case MenuStates.Pause:
                //CloseAllPanels();
                panels[5].SetActive(true);
                pauseButton.gameObject.SetActive(false);
                //overlay.SetActive(false);

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

    //This function is assigned to buttons such as Join / Host game etc, then the scene name is declared in the inspector.
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        CloseAllPanels();

    }





}



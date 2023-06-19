using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStateMachine : MonoBehaviour
{
    //Singleton Class
    public static GameplayStateMachine instance { get; private set; }
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



    Timer timerClass;

    public GameplayState gameplayState;
    public enum GameplayState
    {
        Menu,
        GameStart,
        Player1Turn,
        Player2Turn,
        ActionReplay,
        Win,
        Lose,

    }

    private void Start()
    {
        gameplayState = GameplayState.Menu;
        timerClass = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        ChangeGameState();
    }

    public void CoinToss()
    {
        int coinToss = Random.Range(0, 100);

        if (coinToss <= 50)
        {
            
            timerClass.turnTimer = 45;
            gameplayState = GameplayState.Player1Turn;

            Debug.Log("player one turn");
        }
        else
        {

            timerClass.turnTimer = 45;
            gameplayState = GameplayState.Player2Turn;

            Debug.Log("player two turn");
        }

        Debug.Log(coinToss);
    }

    public void EndTurn()
    {
        if (gameplayState == GameplayState.Player1Turn)
        {
            gameplayState = GameplayState.Player2Turn;
            timerClass.turnTimer = 45;
            Debug.Log("Player 2 turn");
        }
        else if (gameplayState == GameplayState.Player1Turn)
        {
            gameplayState = GameplayState.Player1Turn;
            timerClass.turnTimer = 45;
            Debug.Log("Player 1 turn");
        }

    }

    public void ChangeGameState()
    {
        switch (gameplayState)
        {
            case GameplayState.Menu:
                //Do nothing

                break;
            case GameplayState.GameStart:
                CoinToss();

                break;
            case GameplayState.Player1Turn:

                //Allow actions for player 1
                //Stop actions for player 2 - Pause button should still be accessable.

                break;
            case GameplayState.Player2Turn:

                //Allow actions for player 2
                //Stop actions for player 1 - Pause button should still be accessable.

                break;
            case GameplayState.ActionReplay:

                //Transfer Data? Show actions taken by enemy.

                break;
            case GameplayState.Win:

                //XP +2, Save XP total.

                break;
            case GameplayState.Lose:

                //XP +1, Save XP total

                break;
            default:

                Debug.LogWarning("Something failed in the StateMachine");

                break;
        }




    }

}

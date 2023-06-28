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
        PlayerTurn,
        OpponentTurn,
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
            gameplayState = GameplayState.PlayerTurn;
            Debug.Log("player one turn");
        }
        else
        {
            timerClass.turnTimer = 45;
            gameplayState = GameplayState.OpponentTurn;
            Debug.Log("player two turn");
        }
        Debug.Log(coinToss);
    }

    public void EndTurn()
    {
        if (gameplayState == GameplayState.PlayerTurn)
        {
            Debug.Log("Player turn ended");
            StartCoroutine(TurnTransition(GameplayState.OpponentTurn));
        }
        else if (gameplayState == GameplayState.OpponentTurn)
        {
            Debug.Log("Opponent turn ended");
            StartCoroutine(TurnTransition(GameplayState.PlayerTurn));
        }
    }

    IEnumerator TurnTransition(GameplayState nextTurn)
    {
        gameplayState = GameplayState.ActionReplay;
        timerClass.turnTimer = 45;
        //do replay stuff
        yield return new WaitForSeconds(3f);
        gameplayState = nextTurn;
        yield return null;
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
            case GameplayState.PlayerTurn:
                //Allow actions for player 1
                //Stop actions for player 2 - Pause button should still be accessable.
                break;
            case GameplayState.OpponentTurn:

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float turnTimer = 45;
    public bool timerOn = false;

    public Text timerText;

    GameplayStateMachine gameplayStateMachineClass;

    private void Start()
    {
        gameplayStateMachineClass = FindObjectOfType<GameplayStateMachine>();        
    }

    private void Update()
    {
        if (timerOn && turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
            timerText.text = turnTimer.ToString("00:00");
        }

        if (timerOn && turnTimer <= 0)
        {
            gameplayStateMachineClass.EndTurn();
        }
    }



}

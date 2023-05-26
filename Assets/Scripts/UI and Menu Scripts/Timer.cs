using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float turnTimer = 15;
    public bool timerOn = false;

    public Text timerText;

    MenuHandler menuHandlerClass;

    private void Start()
    {
        menuHandlerClass = FindObjectOfType<MenuHandler>();        
    }

    private void Update()
    {
        if (timerOn && turnTimer > 0)
        {
            turnTimer -= Time.deltaTime;
            timerText.text = turnTimer.ToString();
        }

        if (timerOn && turnTimer <= 0)
        {
            menuHandlerClass.EndTurn();
            turnTimer = 15;
        }
    }



}

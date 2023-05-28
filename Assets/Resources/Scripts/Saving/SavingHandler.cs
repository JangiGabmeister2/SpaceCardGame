using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SavingHandler : MonoBehaviour
{
    [Header("Player Win Event")]
    public UnityEvent onMatchWin;
    [Header("Player Lose Event")]
    public UnityEvent onMatchLoss;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("localPlayer").GetComponent<PlayerStats>();

        onMatchWin.AddListener(IncreaseWinCount);
        onMatchLoss.AddListener(IncreaseLoseCount);
    }

    public void SaveDeck()
    {

    }

    public void GetChosenDeck()
    {
        
    }

    public int GetPlayerLevel()
    {
        int level = PlayerPrefs.GetInt("player_level", 1);

        return level;
    }

    public void GetPlayerValuesRemaining()
    {

    }

    public int GetNumberOfCardsRemaining()
    {
        int count = 0;
        return count;
    }

    public void CalculateExperienceEarned()
    {
        //experience is calculated by:
        //number of cards used, the level of cards used,
        //number of turns played, time elapsed during each turn,
        //amount of health/morale/resources/cards remaining, etc

        //match loss = exp earned / 2

        //calculate experience
    }

    public void CalculateCardsEarned()
    {
        //cards that are unlocked at the end of the match, if any, are calculated on:
        //most used attack types and most used faction types

        //match loss = cards earned / 2
    }

    private void IncreasePlayerLevel()
    {
        //after experience calculations
        //if next level requirements are reached with total experience gained

        //increase player level
        int oldLevel = PlayerPrefs.GetInt("player_level", 1);
        PlayerPrefs.SetInt("player_level", oldLevel + 1);
    }

    //at the end of the match, if match win, increases win count in player stats
    public void IncreaseWinCount()
    {
        int previousWins = PlayerPrefs.GetInt("match_wins", 0);
        PlayerPrefs.SetInt("match_wins", previousWins + 1);
    }

    //at the end of the match, if match loss, increases lose count in player stats
    public void IncreaseLoseCount()
    {
        int previousLosses = PlayerPrefs.GetInt("match_losses", 0);
        PlayerPrefs.SetInt("match_losses", previousLosses + 1);
    }
}

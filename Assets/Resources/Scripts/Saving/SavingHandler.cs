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

    [SerializeField] AudioSource[] audioSources;

    private void Start()
    {

    }

    public void SaveChosenDeck()
    {
        //used in Deck Builder, after choosing a deck to play, saves deck to use for future matches
    }

    public void GetChosenDeck()
    {
        //before the match starts, gets deck data from each player's playerprefs
        //if no deck was chosen (above), a default deck is automatically chosen
    }

    //gets the player's level to display when joining servers and during matches
    public int GetPlayerLevel()
    {
        int level = PlayerPrefs.GetInt("player_level", 1);

        return level;
    }

    //returns amount of experience earned depending on match win or loss
    public int ExperienceEarned(bool matchWin = false)
    {
        int xpCurrent = PlayerPrefs.GetInt("experience_points", 0);

        //match won = 2 xp
        if (matchWin)
        {
            xpCurrent += 2;
        }
        //match loss = 1 xp
        else
        {
            xpCurrent += 1;
        }

        return xpCurrent;
    }

    public void CalculateCardsEarned()
    {
        int xpLevel = PlayerPrefs.GetInt("experience_points", 0);

        //if xp level after gaining current match xp reaches 10, player increases level and gains new card
        if (xpLevel + ExperienceEarned() >= 10)
        {
            IncreasePlayerLevel();

            //get new card

            xpLevel = xpLevel - 10;
        }

        PlayerPrefs.SetInt("experience_points", xpLevel);
    }

    private void IncreasePlayerLevel()
    {
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

    #region Settings
    //public void SaveAudioSettings(string audioSourceName)
    //{
    //    float savedVolume = PlayerPrefs.GetFloat($"{audioSourceName}_volume", 50f);

    //    foreach (AudioSource sources in audioSources)
    //    {
    //        if (sources.outputAudioMixerGroup.name == audioSourceName && sources.volume != savedVolume)
    //        {
    //            float newVolume = sources.volume;
    //            PlayerPrefs.SetFloat($"{audioSourceName}_volume", newVolume);
    //        }
    //    }
    //}
    #endregion
}

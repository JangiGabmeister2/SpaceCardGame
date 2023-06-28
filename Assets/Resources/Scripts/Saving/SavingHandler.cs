using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class SavingHandler : MonoBehaviour
{
    #region Instance Singleton
    public static SavingHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Saving Handler already exists! Destorying duplicate!");
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] List<UnitCard> collectables = new List<UnitCard>();
    [SerializeField] List<UnitCard>[] currentCollection = new List<UnitCard>[3];

    private List<UnitCard> cardCollection = new List<UnitCard>();

    //[SerializeField] AudioSource[] audioSources;

    private void Start()
    {
            
    }

    //when called, gets all the card IDs of the cards in custom deck area
    //puts each ID into a string, separated by a comma
    //saves string into player prefs
    public void SaveChosenDeck(List<UnitCard> cardList)
    {
        List<int> selectedDeck = new List<int>();

        //gets the card IDs for every card in the built deck and saves them into a list
        foreach (UnitCard item in cardList)
        {
            int itemID = item.cardID;
            selectedDeck.Add(itemID);
        }

        //gets all card IDs in the list and puts them in a string then saves it into player prefs
        string chosenDeck = string.Join(",", selectedDeck);

        PlayerPrefs.SetString("chosen_deck", chosenDeck);
    }

    //returns a list of cards previously chosen in deck builder (if not, default deck)
    public List<UnitCard> GetChosenDeck()
    {
        //takes the string of card IDs from player prefs
        string savedDeck = PlayerPrefs.GetString("chosen_deck");

        List<int> chosenDeck = new List<int>();

        //separates each ID from separator/comma
        string[] cardsString = savedDeck.Split(',');

        foreach (string card in cardsString)
        {
            //turns the strings back into ints
            chosenDeck.Add(int.Parse(card));
        }

        List<UnitCard> deck = new List<UnitCard>();
        OwnedCardsRefactored collection = GameObject.FindObjectOfType<OwnedCardsRefactored>();
        Debug.Log(collection);

        //for all IDs of cards in chosen deck
        foreach (int cardID in chosenDeck)
        {
            //for each faction of all owned cards
            foreach (List<UnitCard> list in collection.ownedCards)
            {
                //for all cards in each faction
                foreach (UnitCard cards in list)
                {
                    //gets each card via card IDs and puts them into list
                    if (cards.cardID == cardID)
                    {
                        deck.Add(cards);
                    }
                }
            }
        }

        //returns above list of cards
        return deck;
    }

    //when receiving a new card via level up, call this
    public void ReceiveNewCard(int newCardIndex)
    {
        cardCollection.Add(cardCollection[newCardIndex]);

        collectables.RemoveAt(newCardIndex); 
    }

    public List<UnitCard>[] UpdateCardCollection()
    {
        List<UnitCard>[] newCards = new List<UnitCard>[3];

        return null;
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

        UnitCard randoCard;

        //if xp level after gaining current match xp reaches 10, player increases level and gains new card
        if (xpLevel + ExperienceEarned() >= 10)
        {
            IncreasePlayerLevel();

            int randomCard = Random.Range(0, collectables.Count);
            randoCard = collectables[randomCard];
            collectables.RemoveAt(randomCard);

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

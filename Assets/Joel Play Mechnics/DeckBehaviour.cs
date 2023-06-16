using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckBehaviour : MonoBehaviour
{
    #region Variables ----------------------------------------------------------------

   
    public List<UnitCard> deck = new List<UnitCard>(); //Saved Deck (from deck builder or default)
    public List<UnitCard> inGameDeck = new List<UnitCard>(); //The local version of the selected deck
    public List<UnitCard> hand = new List<UnitCard>(); //currentHand
    public List<UnitCard> currentBoardCards = new List<UnitCard>(); //current deck that is on the board
    public List<UnitCard> drawPile = new List<UnitCard>(); //currentDrawPile
    public List<UnitCard> enemyDeck = new List<UnitCard>(); //enemyPlayedDeck

    public GameObject[] deckPos; //The position of the the deck
    public GameObject[] handPos; //The position of the hand
    public GameObject[] enemyPos; //The position of the enemy deck
    public GameObject[] covers; //the covers for the deck

    public UnitCard blankCard;

    public GameObject clickedCard;
    public GameObject hoverCard;

    public Material placeable, baseMat;
    
    public int _handLimit = 5;
    public float hoverTimer = 2;
    public bool isPlayingCard = false;
    
    public GameObject cardPrefab;
    public GameObject hoverInfoPanel; 

    #endregion

    private void Start()
    {
        PullCards();
        SetCards();
        UpdatePreviewPlayer();
        UpdatePreviewEnemy();
    }

    private void PullCards()
    {
        //pull from menu / local for whatever the players currently selected deck is.
    }

    public void GetEnemyDeck()
    {
        //set the enemy deck list to upto date list
        UpdatePreviewEnemy();
    }
    
    //TODO: GET THIS TO WORK
    public void ShowPlaceable()
    {
        if (clickedCard)
        {
            foreach (var cover in covers)
            {
                cover.GetComponent<MeshRenderer>().material.color = Color.magenta;
            }
        }
        else
        {
            foreach (var cover in covers)
            {
                cover.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void Update()
    {
        ShowPlaceable();
        
        ShaderLogic();
        
        HoverLogic();

        if (Input.GetKeyDown(KeyCode.A)) //for testing purposes
        {
            UpdateHandCards();
            UpdateBoardCards();
            
            DrawCard();
            
            UpdatePreviewPlayer();
            
            //Send to the server
        }
    }
    
    #region GotWorking

    public void ShaderLogic()
    {
        if (!clickedCard) return;
        
        foreach (var pos in deckPos)
        {
            // if (pos.GetComponentInChildren<DeckBasePrefab>().isPlayable)
            // {
            //     Debug.LogWarning("Shader");
            //     pos.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
            //     return;
            // }
            // pos.GetComponent<MeshRenderer>().materials[0].color = Color.white;

        }
    } //Unfinished

    
    public void UpdateBoardCards()
    {
        currentBoardCards.Clear();
        foreach (var t in deckPos)
        {
            currentBoardCards.Add(t.GetComponentInChildren<DeckBasePrefab>().cardSO);
        }
        Debug.Log("Board List Set");
    } //Working

    public void UpdateHandCards()
    {
        hand.Clear();
        foreach (var i in handPos)
        {
            hand.Add(i.GetComponentInChildren<CardBasePrefab>().cardSO);
        }
    } //Working

    public void DrawCard()
    {
        //get top card
        var count = drawPile.Count - 1;
        //if there are any empty spots in the players hand
        for (var i = 0; i < hand.Count; i++)
        {
            if (hand[i] == blankCard)
            {
                Debug.LogWarning("PlayerPickedUp " + drawPile[count]);
                hand[i] = drawPile[count];
                drawPile.RemoveAt(count); //Remove card from draw list
                break;
            }
        }
    } //Working

    private void HoverLogic()
    {
        if (hoverTimer > 0.1 && hoverCard)
        {
            hoverTimer -= Time.deltaTime;
            return;
        }

        if (!hoverCard)
        {
            hoverTimer = 2;
            HoverPanel(false);
            return;
        }

        if (hoverTimer < 0.1)
        {
            HoverPanel(true);
        }
    } //Working
    
    private void SetCards()
    {
        inGameDeck = new List<UnitCard>(deck);

        //shuffle the deck
        for (var i = 0; i < inGameDeck.Count; i++) 
        {
            //current card at index
            var temp = inGameDeck[i];
            //random number above i
            var randomIndex = Random.Range(i, inGameDeck.Count);
            //random card = current card at index
            inGameDeck[i] = inGameDeck[randomIndex];
            inGameDeck[randomIndex] = temp;
        }

        //create the draw pile
        drawPile = new List<UnitCard>(inGameDeck);
        
        //randomly get cards from deck into hand
        for (var i = 0; i < _handLimit; i++)
        {
            //temp card = current card
            var temp = drawPile[i];
            //random number in card list
            var randomIndex = Random.Range(i, drawPile.Count);
            drawPile[i] = drawPile[randomIndex];
            drawPile[randomIndex] = temp;
            //add the new card into hand
            hand.Add(temp);
            //take card out of circulation
            drawPile.Remove(temp);
        }
        foreach (var card in drawPile)
        {
            Debug.LogWarning(card);
        }
    } //Working

    private void UpdatePreviewEnemy()
    {
        //update the enemy stats / deck / board
        for (var i = 0; i < enemyPos.Length; i++)
        {
            if (i >= enemyDeck.Count) return;
            enemyPos[i].GetComponentInChildren<CardBasePrefab>().cardSO = enemyDeck[i];
            enemyPos[i].GetComponentInChildren<CardBasePrefab>().FillData();
        }
    }
    private void UpdatePreviewPlayer()
    {
        //update the player stats / deck / board / hand
        for (var i = 0; i < handPos.Length; i++)
        {
            handPos[i].GetComponentInChildren<CardBasePrefab>().cardSO = hand[i];
            handPos[i].GetComponentInChildren<CardBasePrefab>().FillData();
        }
    }

    public void HoverPanel(bool hover)
    {
        if (!hoverCard) return;
        hoverInfoPanel.GetComponent<HoverPanel>().cardSO = hoverCard.GetComponent<CardBasePrefab>().cardSO;
        hoverInfoPanel.SetActive(hover);
        hoverInfoPanel.GetComponent<HoverPanel>().FillData();
    }
    
    public void HoverPanel(bool hover, UnitCard card)
    {
        hoverInfoPanel.GetComponent<HoverPanel>().cardSO = card;
        hoverInfoPanel.SetActive(hover);
        hoverInfoPanel.GetComponent<HoverPanel>().FillData();
    }
    
    public void ForfeitGame()
    {
        //add functionality to quit game
        
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    
    #endregion
    
}

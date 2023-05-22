using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DeckBehaviour : MonoBehaviour
{
    public Text drawPileCount;
    public DeckSO currentDeck;
    public DeckSO localDeck;
    
    //the prefab f the base card
    public GameObject cardPrefab;
    public GameObject hoverInfoPanel;

    
    //TODO: PLACE THE OBJECTS IN THE ARRAY IN ORDER FROM 0 - 4 / 1-5
    //the 3D gameobject that will be used to place cards in the game 
    public GameObject[] deckSpot;
    //the 2D gameobject that will be used for the hand cards
    public GameObject[] handPositions;
    public Button drawButton;

    private readonly int _handLimit = 5;
    private int _cardsLeftInDrawPile = 99;
    private Camera _mainCamera;
    private GameObject _currentHoverObject;
    //Total card of the deck left
    private List<BaseCard> _cards = new List<BaseCard>();
    private List<BaseCard> _currentHand = new List<BaseCard>();
    private List<BaseCard> _drawPile = new List<BaseCard>();

    

    // Start is called before the first frame update
    private void Start()
    {
        hoverInfoPanel.SetActive(false);
        
        _mainCamera = Camera.main;

        SetCards();
        
        SpawnCards();
    }

    public void SpawnCards()
    {
        //Instantiate the prefabs
        for (var i = 0; i < 5; i++)
        {
            var card = cardPrefab;
            card.GetComponent<CardBase>().so = _currentHand[i];
            Instantiate(card, handPositions[i].transform);
        }
    }

    public void SetCards()
    {
        localDeck.cards.Clear();
        localDeck.cards = currentDeck.cards;
        
        //get all the cards from your deck
        foreach (var i in localDeck.cards)
        {
            _cards.Add(i);
        }

        foreach (var card in _cards)
        {
            Debug.LogError(card);
        }
        
        //shuffle the deck
        for (var i = 0; i < _cards.Count; i++) 
        {
            //current card at index
            var temp = _cards[i];
            //random number above i
            var randomIndex = Random.Range(i, _cards.Count);
            //random card = current card at index
            _cards[i] = _cards[randomIndex];
            _cards[randomIndex] = temp;
        }

        //randomly get cards from deck into hand
        for (var i = 0; i < _handLimit; i++)
        {
            //temp card = current card
            var temp = _cards[i];
            //random number in card list
            var randomIndex = Random.Range(i, _cards.Count);
            _cards[i] = _cards[randomIndex];
            _cards[randomIndex] = temp;
            //add the new card into hand
            _currentHand.Add(temp);
            //take card out of circulation
            _cards.Remove(temp);
        }

        //create the draw pile
        foreach (var i in _cards)
        {
            _drawPile.Add(i);
        }

        foreach (var card in _currentHand)
        {
            //Debug.LogError(card);
        }
        foreach (var card in _drawPile)
        {
            //Debug.LogWarning(card);
        }
    }

    private void Update()
    {
        _cardsLeftInDrawPile = _drawPile.Count;
        drawPileCount.text = _cardsLeftInDrawPile.ToString();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100, 3))
        {
            OffHover();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            ClickCard(hit);
            Debug.LogError("Click on" + hit.transform.gameObject.name);
            return;
        }
        if (Input.GetMouseButton(0))
        {
            MoveCard(hit);
            Debug.Log("Currently Dragging" + hit.transform.gameObject.name);
            return;
        }
        HoverCard(hit);
    }

    public void OffHover()
    {
        hoverInfoPanel.SetActive(false);
    }

    public void HoverCard(RaycastHit hit)
    {
        var o = hit.transform.gameObject;
        _currentHoverObject = o;
        if (o.gameObject.GetComponent<CardBase>().isInHand)
        {
            hoverInfoPanel.GetComponentInChildren<CardBase>().so = o.GetComponent<CardBase>().so;
        }
        Debug.Log("currently hovering over" + o);
        hoverInfoPanel.SetActive(true);
    }

    public void ClickCard(RaycastHit hit)
    {
        
    }
    
    public void MoveCard(RaycastHit hit)
    {
        
    }

    IEnumerator WaitForSec(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    // Update is called once per frame
    public void DrawCard()
    {
        if (_currentHand.Count >= _handLimit)
        {
            Debug.LogError("FAILED to draw");
            return;
        }
        
        _currentHand.Add(_drawPile[Random.Range(0, _drawPile.Count)]);

        //draw the card into the hand
        //update the hand ui
    }

    public void PlayCard()
    {
        if (_currentHand.Count <= 0)
        {
            return;
        }
        //play card onto deck


        //update the hand + deck ui
    }

    public void ForfeitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}

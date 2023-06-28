using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckBasePrefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isPlayable, isEnemyDeck;
    
    public GameObject cover;
    
    public Text cardName;
    public Text cardCost;
    public Text cardHull;

    public Image cardBackground;
    public Image cardSprite;
    
    public UnitCard blankCard;
    public UnitCard cardSO;
    
    public Material clickedMat, baseMat;
    public CardBehaviour cardBehaviour;
    public DeckBehaviour deckBehaviour;

    public DeckBasePrefab target;

    private void Start()
    {
        cardBehaviour = GetComponent<CardBehaviour>();
        deckBehaviour = GameObject.Find("GameHandler").GetComponent<DeckBehaviour>();

        if (CompareTag("EnemyDeck"))
        {
            isEnemyDeck = true;
            isPlayable = false;
            FillData();
            return;
        }
        isPlayable = true;
        FillData();
    }
    
    public void CheckDead()
    {
        
    }

    private void Update()
    {

        CheckDead();
        
        cardBehaviour.baseCard = cardSO;

        if (isEnemyDeck)
        {
            if (cardSO != blankCard)
            {
                cover.SetActive(false);
                FillData();
            }
            else
            {
                cover.SetActive(true);
            }
            return;
        }

        cardBackground.material = deckBehaviour.clickedCard == gameObject ? clickedMat : baseMat;

        bool _uiIsActive;
        
        if (cardSO == blankCard)
        {
            cover.SetActive(true);
            _uiIsActive = false;
            isPlayable = true;
        }
        else
        {
            cover.SetActive(false);
            _uiIsActive = true;
            isPlayable = false;
        }
        SetDeckUI(_uiIsActive);
    }

    public void SetDeckUI(bool active)
    {
        cardName.gameObject.SetActive(active);
        cardCost.gameObject.SetActive(active);
        cardSprite.gameObject.SetActive(active);
        cardHull.gameObject.SetActive(active);
    }

    public void FillData()
    {
        cardName.text = cardSO.name;
        cardCost.text = cardSO.resourceCost.ToString();
        cardHull.text = cardSO.hull.ToString();

        cardSprite.sprite = cardSO.cardArt;
        cardSprite.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Scale(false);
        deckBehaviour.HoverPanel(false, blankCard);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //select player card on field
        if (deckBehaviour.clickedCard == null & !isEnemyDeck)
        {
            deckBehaviour.clickedCard = this.gameObject;
            return;
        }
        //hover view enemy card
        if (isEnemyDeck & cardSO != blankCard)
        {
            deckBehaviour.HoverPanel(true, cardSO);
            return;
        }

        //targeting enemy if player card currently selected
        if (isEnemyDeck & deckBehaviour.clickedCard.GetComponent<DeckBasePrefab>())
        {
            deckBehaviour.clickedCard.GetComponent<DeckBasePrefab>().target = this;
            deckBehaviour.clickedCard = null;
            return;
        }
        
        //if selected card from hand is played onto a blank field slot
        if (deckBehaviour.clickedCard && cardSO == blankCard)
        {
            //if the deck behaviour has a clicked card and this card is placeable then place the card
            cardSO = deckBehaviour.clickedCard.GetComponent<CardBasePrefab>().cardSO;
            deckBehaviour.clickedCard.GetComponent<CardBasePrefab>().cardSO = blankCard;
            cardSO.OnPlayed();
            FillData();
            cover.SetActive(false);
            
            deckBehaviour.clickedCard = null;
        }
        else if (cardSO != blankCard)
        {
            //if card is in play then select it
            deckBehaviour.clickedCard = gameObject;
        }
        else
        {
            deckBehaviour.clickedCard = null;
        }
    }
    

    private void Scale(bool up)
    {
        if (up)
        {
            transform.localScale *= 1.1f;
            return;
        }
        transform.localScale *= 0.90909090909090909090909090909090909090909090909090f;
    }
}

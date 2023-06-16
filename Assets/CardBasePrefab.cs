using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBasePrefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text cardName;
    public Text cardCost;
    public Text cardHull;

    public Image cardBackground;
    
    public Material clickedMat, baseMat;

    public Image cardSprite;

    public UnitCard cardSO; 
    
    public UnitCard blankCard;

    public CardBehaviour cardBehaviour;
    
    public GameObject cover;
    
    public bool isClicked, isHovered;
    
    public DeckBehaviour deckBehaviour;

    private void Start()
    {
        cardBehaviour = GetComponent<CardBehaviour>();
        deckBehaviour = GameObject.Find("GameHandler").GetComponent<DeckBehaviour>();
        FillData();
    }

    public void FillData()
    {
        cardBehaviour.baseCard = cardSO;
        cardName.text = cardSO.name;
        cardCost.text = cardSO.resourceCost.ToString();
        cardHull.text = cardSO.hull.ToString();

        cardSprite.sprite = cardSO.cardArt;
        cardSprite.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        deckBehaviour.hoverCard = gameObject;
        isHovered = true;
        Scale(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        deckBehaviour.hoverCard = null;
        isHovered = false;
        Scale(false);
        deckBehaviour.hoverInfoPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //clicking the same card twice
        if (isClicked)
        {
            deckBehaviour.clickedCard = null;
            deckBehaviour.hoverCard = null;
            isHovered = false;
            isClicked = false;
            return;
        }
        isHovered = false;
        deckBehaviour.hoverCard = null; 
        deckBehaviour.clickedCard = gameObject;
        isClicked = true;
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

    
    
    private void Update()
    {
        
        if (!cardSO == blankCard)
        {
            if(cardSO != cardSO)
            {
                cardSO = Instantiate(cardSO);
            }
        }

        cardBackground.material = deckBehaviour.clickedCard == gameObject ? clickedMat : baseMat;

        SetDeckUI(cardSO != blankCard);
    }
    
    public void SetDeckUI(bool active)
    {
        cover.SetActive(!active);
        cardName.gameObject.SetActive(active);
        cardCost.gameObject.SetActive(active);
        cardSprite.gameObject.SetActive(active);
        cardHull.gameObject.SetActive(active);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverPanel : MonoBehaviour
{
    public Text cardName, cardHull, cardCost, cardDescription, cardAttack, cardResource, cardEffect;


    public Image cardSprite;
    public DeckBehaviour deckBehaviour;
    public UnitCard cardSO;

    private void Start()
    {
        deckBehaviour = GameObject.Find("GameHandler").GetComponent<DeckBehaviour>();
        FillData();
        gameObject.SetActive(false);
    }
    public void FillData()
    {
        
        cardName.text = cardSO.name;
        cardCost.text = cardSO.resourceCost.ToString();
        cardHull.text = cardSO.hull.ToString();
        cardAttack.text = cardSO.attackDamage.ToString();
        cardDescription.text = cardSO.cardDescription;
        cardResource.text = cardSO.resourceCost.ToString();

        cardSprite.sprite = cardSO.cardArt;
        cardSprite.color = Color.white;
    }

    private void Update()
    {
        if (deckBehaviour.hoverCard)
        { 
            cardSO = deckBehaviour.hoverCard.GetComponent<CardBasePrefab>().cardSO;
        }
    }
}

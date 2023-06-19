using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardContents : MonoBehaviour, IPointerDownHandler
{
    public UnitCard cardScriptableObject;

    [Space(20)]
    public Image cardBackground;
    public Image cardIcon;
    public Text cardName, hullValue, shieldValue, costValue, attackStrength, cardFaction;
    public Text description;
    public Text index;

    [HideInInspector] public bool doublClicked = false;

    private void Awake()
    {
        cardFaction.text = "Faction:\n" + cardScriptableObject.factionType;

        cardBackground.sprite = cardScriptableObject.cardBackground;
        cardIcon.sprite = cardScriptableObject.cardArt;

        cardName.text = "Name:" + cardScriptableObject.cardName;
        description.text = "Description:\n" + cardScriptableObject.cardDescription;

        hullValue.text = "Hull: " + cardScriptableObject.hull.ToString();
        shieldValue.text = "Shield: " + cardScriptableObject.shield.ToString();
        costValue.text = "Cost: " + cardScriptableObject.resourceCost.ToString();
        attackStrength.text = "Attack: " + cardScriptableObject.attackDamage.ToString();
    }

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    
    public void OnPointerDown(PointerEventData data)
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;
    
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
    
            doublClicked = true;
    
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
    
    }
}

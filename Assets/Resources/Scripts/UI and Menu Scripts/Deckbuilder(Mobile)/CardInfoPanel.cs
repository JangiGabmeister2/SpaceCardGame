using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardInfoPanel : MonoBehaviour
{
    public Text selectedCardName;
    public Text selectedCardHull;
    public Text selectedCardShield;
    public Text selectedCardCost;
    public Text selectedCardAttack;
    public Text selectedCardDescription;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateInfoPanel(UnitCard thisCard)
    {
  
        selectedCardName.text = "Name: " + thisCard.cardName.ToString();
        selectedCardHull.text = "Hull Value: " + thisCard.hull.ToString();
        selectedCardCost.text = "Resource Cost: " + thisCard.resourceCost.ToString();
        selectedCardShield.text = "Shield Value: " + thisCard.shield.ToString();
        selectedCardAttack.text = "Attack Value: " + thisCard.attackDamage.ToString();
        selectedCardDescription.text = "Description: " + thisCard.cardDescription.ToString();
    }
}

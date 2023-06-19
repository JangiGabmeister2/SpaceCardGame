using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromDeck : MonoBehaviour
{
    OwnedCards ownedCardsClass;


    private void Start()
    {
        ownedCardsClass = FindObjectOfType<OwnedCards>();
    }

    public void ClearDeck()
    {
 
        ownedCardsClass.cardCountPos1 = 2;
        ownedCardsClass.cardCountPos2 = 2;

        ownedCardsClass.cardCountTextPos1.text = ownedCardsClass.cardCountPos1.ToString();
        ownedCardsClass.cardCountTextPos2.text = ownedCardsClass.cardCountPos2.ToString();


        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}

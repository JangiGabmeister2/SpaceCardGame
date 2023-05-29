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
        //This isnt working to return the card count number
        ownedCardsClass.cardCountPos1 = 2;
        ownedCardsClass.cardCountPos2 = 2;


        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}

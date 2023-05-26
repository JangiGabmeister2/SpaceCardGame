using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddToDeck : MonoBehaviour
{
    OwnedCards ownedCardsClass;
    DeckBuild deckBuildClass;

    public GameObject cardDrop;


    private void Start()
    {
        ownedCardsClass = FindObjectOfType<OwnedCards>();
        deckBuildClass = FindObjectOfType<DeckBuild>();
    }

    private void Update()
    {
        
    }

    //I have not tested this function and was just typing ahead of time, at present, there is no way to select the cards or transfer them from one array to another.
    public void AddCardsToDeck()
    {
        for (int i = 0; i < deckBuildClass.deckBuildCards.Length; i++)
        {
            i++;
        }
    }


}

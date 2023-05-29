using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddToDeck : MonoBehaviour
{
    OwnedCards ownedCardsClass;
    DeckBuild deckBuildClass;


    private void Start()
    {
        ownedCardsClass = FindObjectOfType<OwnedCards>();
        deckBuildClass = FindObjectOfType<DeckBuild>();
    }

    private void Update()
    {
        
    }




}

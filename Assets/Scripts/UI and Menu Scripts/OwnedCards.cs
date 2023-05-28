using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnedCards : MonoBehaviour
{


    /// <summary>
    /// The intention of this class is to keep a record of any unlocked cards and how many of each card is owned. I have kept the max to 10 just for testing purpose.
    /// What I am attempting to do below, is instantiate each card (Which at this stage is predefined in the inspector) using just a prefab of an empty game object and image to act as a temp card.
    /// The card is instantiated to the parent, which in this case has a 'grid layout' component. It works, but there are issues atm such as the mask not working to 'cut off' the scroll,
    /// there being a gap before the first 'card' is displayed. Other than that it works mostly.
    /// 
    /// I may need to create a new class with an interface which does raycasts to the card to select them. The intention is, to select a card, have that card be taken into a variable,
    /// then either drag it over to the (green) square on the panel to 'add it' to the deck builder, or to remove the green square and have a button that adds it to the deck.
    /// Either way that is chosen needs to be delcared when clicked on, then either dragged over, or a button clicked to add it to the deck build array.
    /// 
    /// The idea is that it will remove a card from the ownedcards array, and add it to the DeckBuild array, and vice versa with the 'remove from deck' class.
    /// </summary>

    //public int maxCards = 10; // For now

    public GameObject[] ownedCards;
    public Transform[] cardPlacements;

    DeckBuild deckBuildClass;



    private void Start()
    {

        deckBuildClass = FindObjectOfType<DeckBuild>();
        SpawnOwnedCards();
    }



    public void SpawnOwnedCards()
    {

        Instantiate(ownedCards[0], cardPlacements[0]);
        Instantiate(ownedCards[1], cardPlacements[1]);
        Instantiate(ownedCards[2], cardPlacements[2]);
        Instantiate(ownedCards[3], cardPlacements[3]);
        Instantiate(ownedCards[4], cardPlacements[4]);
        Instantiate(ownedCards[5], cardPlacements[5]);
        Instantiate(ownedCards[6], cardPlacements[6]);
        Instantiate(ownedCards[7], cardPlacements[7]);
        Instantiate(ownedCards[8], cardPlacements[8]);

        /*Instantiate(ownedCards[0], cardPlacements);
        Instantiate(ownedCards[1], cardPlacements);
        Instantiate(ownedCards[2], cardPlacements);
        Instantiate(ownedCards[3], cardPlacements);
        Instantiate(ownedCards[4], cardPlacements);
        Instantiate(ownedCards[5], cardPlacements);
        Instantiate(ownedCards[6], cardPlacements);
        Instantiate(ownedCards[7], cardPlacements);
        Instantiate(ownedCards[8], cardPlacements);
        Instantiate(ownedCards[9], cardPlacements);*/

    }


}

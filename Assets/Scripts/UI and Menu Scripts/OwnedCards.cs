using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnedCards : MonoBehaviour
{

    public List<GameObject> ownedCardsSwarmer = new List<GameObject>();
    public List<GameObject> ownedCardsIronSide = new List<GameObject>();
    public List<GameObject> ownedCardsMidling = new List<GameObject>();
    public List<GameObject> builtDeck = new List<GameObject>();
    public List<Transform> builtCardPlacements = new List<Transform>();
    public Transform deckPlacements;
    public GameObject deckContainer;

    public RemoveFromDeck removeFromDeckClass;



    #region Card Placement Positions

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public Transform pos9;
    public Transform pos10;
    public Transform pos11;
    public Transform pos12;
    public Transform pos13;
    public Transform pos14;
    public Transform pos15;
    public Transform pos16;
    public Transform pos17;
    public Transform pos18;
    public Transform pos19;
    public Transform pos20;



    #endregion

    #region Card Counts

    public int cardCountPos1;
    public int cardCountPos2;
    public int cardCountPos3;
    public int cardCountPos4;
    public int cardCountPos5;
    public int cardCountPos6;
    public int cardCountPos7;
    public int cardCountPos8;
    public int cardCountPos9;
    public int cardCountPos10;
    public int cardCountPos11;
    public int cardCountPos12;
    public int cardCountPos13;
    public int cardCountPos14;
    public int cardCountPos15;
    public int cardCountPos16;
    public int cardCountPos17;
    public int cardCountPos18;
    public int cardCountPos19;
    public int cardCountPos20;


    public Text cardCountTextPos1;
    public Text cardCountTextPos2;
    public Text cardCountTextPos3;
    public Text cardCountTextPos4;
    public Text cardCountTextPos5;
    public Text cardCountTextPos6;
    public Text cardCountTextPos7;
    public Text cardCountTextPos8;
    public Text cardCountTextPos9;
    public Text cardCountTextPos10;
    public Text cardCountTextPos11;
    public Text cardCountTextPos12;
    public Text cardCountTextPos13;
    public Text cardCountTextPos14;
    public Text cardCountTextPos15;
    public Text cardCountTextPos16;
    public Text cardCountTextPos17;
    public Text cardCountTextPos18;
    public Text cardCountTextPos19;
    public Text cardCountTextPos20;




    #endregion

    #region cardGO's

    public GameObject cardSwarmer1;
    public GameObject cardSwarmer2;
    public GameObject cardSwarmer3;
    public GameObject cardSwarmer4;
    public GameObject cardSwarmer5;
    public GameObject cardSwarmer6;
    public GameObject cardSwarmer7;
    public GameObject cardSwarmer8;
    public GameObject cardSwarmer9;
    public GameObject cardSwarmer10;
    public GameObject cardSwarmer11;
    public GameObject cardSwarmer12;
    public GameObject cardSwarmer13;
    public GameObject cardSwarmer14;
    public GameObject cardSwarmer15;
    public GameObject cardSwarmer16;
    public GameObject cardSwarmer17;
    public GameObject cardSwarmer18;
    public GameObject cardSwarmer19;
    public GameObject cardSwarmer20;

    public GameObject cardIronSide1;
    public GameObject cardIronSide2;
    public GameObject cardIronSide3;
    public GameObject cardIronSide4;
    public GameObject cardIronSide5;
    public GameObject cardIronSide6;
    public GameObject cardIronSide7;
    public GameObject cardIronSide8;
    public GameObject cardIronSide9;
    public GameObject cardIronSide10;
    public GameObject cardIronSide11;
    public GameObject cardIronSide12;
    public GameObject cardIronSide13;
    public GameObject cardIronSide14;
    public GameObject cardIronSide15;
    public GameObject cardIronSide16;
    public GameObject cardIronSide17;
    public GameObject cardIronSide18;
    public GameObject cardIronSide19;
    public GameObject cardIronSide20;

    public GameObject cardMidling1;
    public GameObject cardMidling2;
    public GameObject cardMidling3;
    public GameObject cardMidling4;
    public GameObject cardMidling5;
    public GameObject cardMidling6;
    public GameObject cardMidling7;
    public GameObject cardMidling8;
    public GameObject cardMidling9;
    public GameObject cardMidling10;
    public GameObject cardMidling11;
    public GameObject cardMidling12;
    public GameObject cardMidling13;
    public GameObject cardMidling14;
    public GameObject cardMidling15;
    public GameObject cardMidling16;
    public GameObject cardMidling17;
    public GameObject cardMidling18;
    public GameObject cardMidling19;
    public GameObject cardMidling20;






    #endregion

    #region owned cards


    #endregion

    private void Start()
    {
        AddPositionsToList();
        AddCardCount();
        ChangeFaction(0);

        removeFromDeckClass = FindObjectOfType<RemoveFromDeck>();

    }


    #region Switch factions

    public enum Faction
    {
        Swarmer,
        IronSide,
        Midling
    }

    public Faction factionChange;

    public void ChangeFaction(int value)
    {
        factionChange = (Faction)value;

        switch (factionChange)
        {
            case Faction.Swarmer:

                RemoveOwnedCardsIronSide();
                RemoveOwnedCardsMidling();
                RemoveCards();
                AddSwarmerCardsToOwned();
                SpawnOwnedCardsSwarmer();
                break;

            case Faction.IronSide:

                RemoveOwnedCardsSwarmer();
                RemoveOwnedCardsMidling();
                RemoveCards();
                AddIronSideCardsToOwned();
                SpawnOwnedCardsIronSide();
                break;

            case Faction.Midling:

                RemoveOwnedCardsSwarmer();
                RemoveOwnedCardsIronSide();
                RemoveCards();
                AddMidlingCardsToOwned();
                SpawnOwnedCardsMidling();
                break;

            default:

                Debug.Log("Something went Wrong");

                break;
        }

    }

    public void ChangeFactionButton()
    {
        if (factionChange == Faction.Swarmer)
        {
            removeFromDeckClass.ClearDeck();
            ChangeFaction(1);

        }
        if (factionChange == Faction.IronSide)
        {
            removeFromDeckClass.ClearDeck();
            ChangeFaction(2);
        }
        if (factionChange == Faction.Midling)
        {
            removeFromDeckClass.ClearDeck();
            ChangeFaction(0);
        }
    }


    #endregion



    public void SpawnOwnedCardsSwarmer()
    {


        Instantiate(ownedCardsSwarmer[0], builtCardPlacements[0]);
        Instantiate(ownedCardsSwarmer[1], builtCardPlacements[1]);
        Instantiate(ownedCardsSwarmer[2], builtCardPlacements[2]);
        Instantiate(ownedCardsSwarmer[3], builtCardPlacements[3]);
        Instantiate(ownedCardsSwarmer[4], builtCardPlacements[4]);
        Instantiate(ownedCardsSwarmer[5], builtCardPlacements[5]);
        Instantiate(ownedCardsSwarmer[6], builtCardPlacements[6]);
        Instantiate(ownedCardsSwarmer[7], builtCardPlacements[7]);
        Instantiate(ownedCardsSwarmer[8], builtCardPlacements[8]);
        Instantiate(ownedCardsSwarmer[9], builtCardPlacements[9]);
        Instantiate(ownedCardsSwarmer[10], builtCardPlacements[10]);
        Instantiate(ownedCardsSwarmer[11], builtCardPlacements[11]);
        Instantiate(ownedCardsSwarmer[12], builtCardPlacements[12]);
        Instantiate(ownedCardsSwarmer[13], builtCardPlacements[13]);
        Instantiate(ownedCardsSwarmer[14], builtCardPlacements[14]);
        Instantiate(ownedCardsSwarmer[15], builtCardPlacements[15]);
        Instantiate(ownedCardsSwarmer[16], builtCardPlacements[16]);
        Instantiate(ownedCardsSwarmer[17], builtCardPlacements[17]);
        Instantiate(ownedCardsSwarmer[18], builtCardPlacements[18]);
        Instantiate(ownedCardsSwarmer[19], builtCardPlacements[19]);
    }

    public void SpawnOwnedCardsIronSide()
    {


        Instantiate(ownedCardsIronSide[0], builtCardPlacements[0]);
        Instantiate(ownedCardsIronSide[1], builtCardPlacements[1]);
        Instantiate(ownedCardsIronSide[2], builtCardPlacements[2]);
        Instantiate(ownedCardsIronSide[3], builtCardPlacements[3]);
        Instantiate(ownedCardsIronSide[4], builtCardPlacements[4]);
        Instantiate(ownedCardsIronSide[5], builtCardPlacements[5]);
        Instantiate(ownedCardsIronSide[6], builtCardPlacements[6]);
        Instantiate(ownedCardsIronSide[7], builtCardPlacements[7]);
        Instantiate(ownedCardsIronSide[8], builtCardPlacements[8]);
        Instantiate(ownedCardsIronSide[9], builtCardPlacements[9]);
        Instantiate(ownedCardsIronSide[10], builtCardPlacements[10]);
        Instantiate(ownedCardsIronSide[11], builtCardPlacements[11]);
        Instantiate(ownedCardsIronSide[12], builtCardPlacements[12]);
        Instantiate(ownedCardsIronSide[13], builtCardPlacements[13]);
        Instantiate(ownedCardsIronSide[14], builtCardPlacements[14]);
        Instantiate(ownedCardsIronSide[15], builtCardPlacements[15]);
        Instantiate(ownedCardsIronSide[16], builtCardPlacements[16]);
        Instantiate(ownedCardsIronSide[17], builtCardPlacements[17]);
        Instantiate(ownedCardsIronSide[18], builtCardPlacements[18]);
        Instantiate(ownedCardsIronSide[19], builtCardPlacements[19]);



    }

    public void SpawnOwnedCardsMidling()
    {
        Instantiate(ownedCardsMidling[0], builtCardPlacements[0]);
        Instantiate(ownedCardsMidling[1], builtCardPlacements[1]);
        Instantiate(ownedCardsMidling[2], builtCardPlacements[2]);
        Instantiate(ownedCardsMidling[3], builtCardPlacements[3]);
        Instantiate(ownedCardsMidling[4], builtCardPlacements[4]);
        Instantiate(ownedCardsMidling[5], builtCardPlacements[5]);
        Instantiate(ownedCardsMidling[6], builtCardPlacements[6]);
        Instantiate(ownedCardsMidling[7], builtCardPlacements[7]);
        Instantiate(ownedCardsMidling[8], builtCardPlacements[8]);
        Instantiate(ownedCardsMidling[9], builtCardPlacements[9]);
        Instantiate(ownedCardsMidling[10], builtCardPlacements[10]);
        Instantiate(ownedCardsMidling[11], builtCardPlacements[11]);
        Instantiate(ownedCardsMidling[12], builtCardPlacements[12]);
        Instantiate(ownedCardsMidling[13], builtCardPlacements[13]);
        Instantiate(ownedCardsMidling[14], builtCardPlacements[14]);
        Instantiate(ownedCardsMidling[15], builtCardPlacements[15]);
        Instantiate(ownedCardsMidling[16], builtCardPlacements[16]);
        Instantiate(ownedCardsMidling[17], builtCardPlacements[17]);
        Instantiate(ownedCardsMidling[18], builtCardPlacements[18]);
        Instantiate(ownedCardsMidling[19], builtCardPlacements[19]);

    }

    public void RemoveOwnedCardsSwarmer()
    {
        Destroy(GameObject.Find("Card 1 Swarmer(Clone)"));
        Destroy(GameObject.Find("Card 2 Swarmer(Clone)"));

    }

    public void RemoveOwnedCardsIronSide()
    {
        Destroy(GameObject.Find("Card 1 IronSide(Clone)"));
        Destroy(GameObject.Find("Card 2 IronSide(Clone)"));

    }

    public void RemoveOwnedCardsMidling()
    {
        Destroy(GameObject.Find("Card 1 Midling(Clone)"));
        Destroy(GameObject.Find("Card 2 Midling(Clone)"));

    }

    public void AddSwarmerCardsToOwned()
    {
        ownedCardsSwarmer.Add(cardSwarmer1);
        ownedCardsSwarmer.Add(cardSwarmer2);

    }

    public void AddIronSideCardsToOwned()
    {
        ownedCardsIronSide.Add(cardIronSide1);
        ownedCardsIronSide.Add(cardIronSide2);
    }

    public void AddMidlingCardsToOwned()
    {
        ownedCardsMidling.Add(cardMidling1);
        ownedCardsMidling.Add(cardMidling2);
    }

    public void RemoveCards()
    {
        ownedCardsSwarmer.Clear();
        ownedCardsIronSide.Clear();
        ownedCardsMidling.Clear();
    }


    #region Add Cards to Deck

    public void AddCardPos1ToDeck()
    {
        if (cardCountPos1 > 0 && factionChange == Faction.Swarmer)
        {
            GameObject card1 = Instantiate(ownedCardsSwarmer[0], deckPlacements);
            card1.name = "Card 1 Swarmer";
            cardCountPos1 -= 1;
            builtDeck.Add(cardSwarmer1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }
        if(cardCountPos1 > 0 && factionChange == Faction.IronSide)
        {
            GameObject card1 = Instantiate(ownedCardsIronSide[0], deckPlacements);
            card1.name = "Card 1 IronSide";
            cardCountPos1 -= 1;
            builtDeck.Add(cardIronSide1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }
        if (cardCountPos1 > 0 && factionChange == Faction.Midling)
        {
            GameObject card1 = Instantiate(ownedCardsMidling[0], deckPlacements);
            card1.name = "Card 1 Midling";
            cardCountPos1 -= 1;
            builtDeck.Add(cardMidling1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }

        else return;

    }

    public void AddCardPos2ToDeck()
    {

        if (cardCountPos2 > 0 && factionChange == Faction.Swarmer)
        {
            GameObject card2 = Instantiate(ownedCardsSwarmer[1], deckPlacements);
            card2.name = "Card 2 Swarmer";
            cardCountPos2 -= 1;
            builtDeck.Add(cardSwarmer2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        if (cardCountPos2 > 0 && factionChange == Faction.IronSide)
        {
            GameObject card2 = Instantiate(ownedCardsIronSide[1], deckPlacements);
            card2.name = "Card 2 IronSide";
            cardCountPos2 -= 1;
            builtDeck.Add(cardIronSide2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        if (cardCountPos2 > 0 && factionChange == Faction.Midling)
        {
            GameObject card2 = Instantiate(ownedCardsMidling[1], deckPlacements);
            card2.name = "Card 2 Midling";
            cardCountPos2 -= 1;
            builtDeck.Add(cardMidling2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        else return;

    }


    public void RemoveCardPos1FromDeck()
    {
        if (cardCountPos1 < 2 && factionChange == Faction.Swarmer)
        {
            cardCountPos1 += 1;
            builtDeck.Remove(cardSwarmer1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 Swarmer"));
        }
        if (cardCountPos1 < 2 && factionChange == Faction.IronSide)
        {
            cardCountPos1 += 1;
            builtDeck.Remove(cardIronSide1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 IronSide"));
        }
        if (cardCountPos1 < 2 && factionChange == Faction.Midling)
        {
            cardCountPos1 += 1;
            builtDeck.Remove(cardMidling1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 Midling"));
        }
        else return;

    }

    public void RemoveCardPos2FromDeck()
    {
        if (cardCountPos2 < 2 && factionChange == Faction.Swarmer)
        {
            cardCountPos2 += 1;
            builtDeck.Remove(cardSwarmer2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 Swarmer"));
        }
        if (cardCountPos2 < 2 && factionChange == Faction.IronSide)
        {
            cardCountPos2 += 1;
            builtDeck.Remove(cardIronSide2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 IronSide"));
        }
        if (cardCountPos2 < 2 && factionChange == Faction.Midling)
        {
            cardCountPos2 += 1;
            builtDeck.Remove(cardMidling2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 Midling"));
        }
        else return;

    }




    #endregion


    #region Remove Cards from Deck



    #endregion


    #region Add Card positions


    public void AddPositionsToList()
    {
        builtCardPlacements.Add(pos1);
        builtCardPlacements.Add(pos2);
        builtCardPlacements.Add(pos3);
        builtCardPlacements.Add(pos4);
        builtCardPlacements.Add(pos5);
        builtCardPlacements.Add(pos6);
        builtCardPlacements.Add(pos7);
        builtCardPlacements.Add(pos8);
        builtCardPlacements.Add(pos9);
        builtCardPlacements.Add(pos10);
        builtCardPlacements.Add(pos11);
        builtCardPlacements.Add(pos12);
        builtCardPlacements.Add(pos13);
        builtCardPlacements.Add(pos14);
        builtCardPlacements.Add(pos15);
        builtCardPlacements.Add(pos16);
        builtCardPlacements.Add(pos17);
        builtCardPlacements.Add(pos18);
        builtCardPlacements.Add(pos19);
        builtCardPlacements.Add(pos20);


    }

    private void AddCardCount()
    {
        cardCountPos1 = 2;
        cardCountPos2 = 2;
        cardCountPos3 = 2;
        cardCountPos4 = 2;
        cardCountPos5 = 2;
        cardCountPos6 = 2;
        cardCountPos7 = 2;
        cardCountPos8 = 2;
        cardCountPos9 = 2;
        cardCountPos10 = 2;
        cardCountPos11 = 2;
        cardCountPos12 = 2;
        cardCountPos13 = 2;
        cardCountPos14 = 2;
        cardCountPos15 = 2;
        cardCountPos16 = 2;
        cardCountPos17 = 2;
        cardCountPos18 = 2;
        cardCountPos19 = 2;
        cardCountPos20 = 2;

        cardCountTextPos1.text = cardCountPos1.ToString();
        cardCountTextPos2.text = cardCountPos2.ToString();
        cardCountTextPos3.text = cardCountPos3.ToString();
        cardCountTextPos4.text = cardCountPos4.ToString();
        cardCountTextPos5.text = cardCountPos5.ToString();
        cardCountTextPos6.text = cardCountPos6.ToString();
        cardCountTextPos7.text = cardCountPos7.ToString();
        cardCountTextPos8.text = cardCountPos8.ToString();
        cardCountTextPos9.text = cardCountPos9.ToString();
        cardCountTextPos10.text = cardCountPos10.ToString();
        cardCountTextPos11.text = cardCountPos11.ToString();
        cardCountTextPos12.text = cardCountPos12.ToString();
        cardCountTextPos13.text = cardCountPos13.ToString();
        cardCountTextPos14.text = cardCountPos14.ToString();
        cardCountTextPos15.text = cardCountPos15.ToString();
        cardCountTextPos16.text = cardCountPos16.ToString();
        cardCountTextPos17.text = cardCountPos17.ToString();
        cardCountTextPos18.text = cardCountPos18.ToString();
        cardCountTextPos19.text = cardCountPos19.ToString();
        cardCountTextPos20.text = cardCountPos20.ToString();
    }

    #endregion
}

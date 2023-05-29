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
    private int CardCountMax;

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


    private void Start()
    {
        CardCountMax = 0;
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
        ownedCardsSwarmer.Add(cardSwarmer3);
        ownedCardsSwarmer.Add(cardSwarmer4);
        ownedCardsSwarmer.Add(cardSwarmer5);
        ownedCardsSwarmer.Add(cardSwarmer6);
        ownedCardsSwarmer.Add(cardSwarmer7);
        ownedCardsSwarmer.Add(cardSwarmer8);
        ownedCardsSwarmer.Add(cardSwarmer9);
        ownedCardsSwarmer.Add(cardSwarmer10);
        ownedCardsSwarmer.Add(cardSwarmer11);
        ownedCardsSwarmer.Add(cardSwarmer12);
        ownedCardsSwarmer.Add(cardSwarmer13);
        ownedCardsSwarmer.Add(cardSwarmer14);
        ownedCardsSwarmer.Add(cardSwarmer15);

    }

    public void AddIronSideCardsToOwned()
    {
        ownedCardsIronSide.Add(cardIronSide1);
        ownedCardsIronSide.Add(cardIronSide2);
        ownedCardsIronSide.Add(cardIronSide3);
        ownedCardsIronSide.Add(cardIronSide4);
        ownedCardsIronSide.Add(cardIronSide5);
        ownedCardsIronSide.Add(cardIronSide6);
        ownedCardsIronSide.Add(cardIronSide7);
        ownedCardsIronSide.Add(cardIronSide8);
        ownedCardsIronSide.Add(cardIronSide9);
        ownedCardsIronSide.Add(cardIronSide10);
        ownedCardsIronSide.Add(cardIronSide11);
        ownedCardsIronSide.Add(cardIronSide12);
        ownedCardsIronSide.Add(cardIronSide13);
        ownedCardsIronSide.Add(cardIronSide14);
        ownedCardsIronSide.Add(cardIronSide15);
    }

    public void AddMidlingCardsToOwned()
    {
        ownedCardsMidling.Add(cardMidling1);
        ownedCardsMidling.Add(cardMidling2);
        ownedCardsMidling.Add(cardMidling3);
        ownedCardsMidling.Add(cardMidling4);
        ownedCardsMidling.Add(cardMidling5);
        ownedCardsMidling.Add(cardMidling6);
        ownedCardsMidling.Add(cardMidling7);
        ownedCardsMidling.Add(cardMidling8);
        ownedCardsMidling.Add(cardMidling9);
        ownedCardsMidling.Add(cardMidling10);
        ownedCardsMidling.Add(cardMidling11);
        ownedCardsMidling.Add(cardMidling12);
        ownedCardsMidling.Add(cardMidling13);
        ownedCardsMidling.Add(cardMidling14);
        ownedCardsMidling.Add(cardMidling15);

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
        if (cardCountPos1 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card1 = Instantiate(ownedCardsSwarmer[0], deckPlacements);
            card1.name = "Card 1 Swarmer";
            cardCountPos1 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }
        if(cardCountPos1 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card1 = Instantiate(ownedCardsIronSide[0], deckPlacements);
            card1.name = "Card 1 IronSide";
            cardCountPos1 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }
        if (cardCountPos1 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card1 = Instantiate(ownedCardsMidling[0], deckPlacements);
            card1.name = "Card 1 Midling";
            cardCountPos1 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling1);
            cardCountTextPos1.text = cardCountPos1.ToString();
        }

        else return;

    }

    public void AddCardPos2ToDeck()
    {

        if (cardCountPos2 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card2 = Instantiate(ownedCardsSwarmer[1], deckPlacements);
            card2.name = "Card 2 Swarmer";
            cardCountPos2 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        if (cardCountPos2 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card2 = Instantiate(ownedCardsIronSide[1], deckPlacements);
            card2.name = "Card 2 IronSide";
            cardCountPos2 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        if (cardCountPos2 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card2 = Instantiate(ownedCardsMidling[1], deckPlacements);
            card2.name = "Card 2 Midling";
            cardCountPos2 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling2);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        else return;

    }

    public void AddCardPos3ToDeck()
    {

        if (cardCountPos3 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card3 = Instantiate(ownedCardsSwarmer[2], deckPlacements);
            card3.name = "Card 3 Swarmer";
            cardCountPos3 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer3);
            cardCountTextPos2.text = cardCountPos2.ToString();
        }
        if (cardCountPos3 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card3 = Instantiate(ownedCardsIronSide[2], deckPlacements);
            card3.name = "Card 3 IronSide";
            cardCountPos3 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide3);
            cardCountTextPos3.text = cardCountPos3.ToString();
        }
        if (cardCountPos3 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card3 = Instantiate(ownedCardsMidling[2], deckPlacements);
            card3.name = "Card 3 Midling";
            cardCountPos3 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling3);
            cardCountTextPos3.text = cardCountPos3.ToString();
        }
        else return;

    }
    public void AddCardPos4ToDeck()
    {

        if (cardCountPos4 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card4 = Instantiate(ownedCardsSwarmer[3], deckPlacements);
            card4.name = "Card 4 Swarmer";
            cardCountPos4 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer4);
            cardCountTextPos4.text = cardCountPos4.ToString();
        }
        if (cardCountPos4 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card4 = Instantiate(ownedCardsIronSide[3], deckPlacements);
            card4.name = "Card 4 IronSide";
            cardCountPos4 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide4);
            cardCountTextPos4.text = cardCountPos4.ToString();
        }
        if (cardCountPos4 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card4 = Instantiate(ownedCardsMidling[3], deckPlacements);
            card4.name = "Card 4 Midling";
            cardCountPos4 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling4);
            cardCountTextPos4.text = cardCountPos4.ToString();
        }
        else return;

    }

    public void AddCardPos5ToDeck()
    {

        if (cardCountPos5 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card5 = Instantiate(ownedCardsSwarmer[4], deckPlacements);
            card5.name = "Card 5 Swarmer";
            cardCountPos5 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer5);
            cardCountTextPos5.text = cardCountPos5.ToString();
        }
        if (cardCountPos5 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card5 = Instantiate(ownedCardsIronSide[4], deckPlacements);
            card5.name = "Card 5 IronSide";
            cardCountPos5 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide5);
            cardCountTextPos5.text = cardCountPos5.ToString();
        }
        if (cardCountPos5 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card5 = Instantiate(ownedCardsMidling[4], deckPlacements);
            card5.name = "Card 5 Midling";
            cardCountPos5 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling5);
            cardCountTextPos5.text = cardCountPos5.ToString();
        }
        else return;

    }

    public void AddCardPos6ToDeck()
    {

        if (cardCountPos6 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card6 = Instantiate(ownedCardsSwarmer[5], deckPlacements);
            card6.name = "Card 6 Swarmer";
            cardCountPos6 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer6);
            cardCountTextPos6.text = cardCountPos6.ToString();
        }
        if (cardCountPos5 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card6 = Instantiate(ownedCardsIronSide[5], deckPlacements);
            card6.name = "Card 6 IronSide";
            cardCountPos6 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide6);
            cardCountTextPos6.text = cardCountPos6.ToString();
        }
        if (cardCountPos6 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card6 = Instantiate(ownedCardsMidling[5], deckPlacements);
            card6.name = "Card 6 Midling";
            cardCountPos6 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling6);
            cardCountTextPos6.text = cardCountPos6.ToString();
        }
        else return;

    }

    public void AddCardPos7ToDeck()
    {

        if (cardCountPos7 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card7 = Instantiate(ownedCardsSwarmer[6], deckPlacements);
            card7.name = "Card 7 Swarmer";
            cardCountPos7 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer7);
            cardCountTextPos7.text = cardCountPos7.ToString();
        }
        if (cardCountPos7 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card7 = Instantiate(ownedCardsIronSide[6], deckPlacements);
            card7.name = "Card 7 IronSide";
            cardCountPos7 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide7);
            cardCountTextPos7.text = cardCountPos7.ToString();
        }
        if (cardCountPos7 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card7 = Instantiate(ownedCardsMidling[6], deckPlacements);
            card7.name = "Card 7 Midling";
            cardCountPos7 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling7);
            cardCountTextPos7.text = cardCountPos7.ToString();
        }
        else return;

    }

    public void AddCardPos8ToDeck()
    {

        if (cardCountPos8 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card8 = Instantiate(ownedCardsSwarmer[7], deckPlacements);
            card8.name = "Card 8 Swarmer";
            cardCountPos8 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer8);
            cardCountTextPos8.text = cardCountPos8.ToString();
        }
        if (cardCountPos8 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card8 = Instantiate(ownedCardsIronSide[7], deckPlacements);
            card8.name = "Card 8 IronSide";
            cardCountPos8 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide8);
            cardCountTextPos8.text = cardCountPos8.ToString();
        }
        if (cardCountPos8 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card8 = Instantiate(ownedCardsMidling[7], deckPlacements);
            card8.name = "Card 8 Midling";
            cardCountPos8 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling8);
            cardCountTextPos8.text = cardCountPos8.ToString();
        }
        else return;

    }

    public void AddCardPos9ToDeck()
    {

        if (cardCountPos9 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card9 = Instantiate(ownedCardsSwarmer[8], deckPlacements);
            card9.name = "Card 9 Swarmer";
            cardCountPos9 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer8);
            cardCountTextPos9.text = cardCountPos9.ToString();
        }
        if (cardCountPos9 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card9 = Instantiate(ownedCardsIronSide[8], deckPlacements);
            card9.name = "Card 9 IronSide";
            cardCountPos9 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide9);
            cardCountTextPos9.text = cardCountPos9.ToString();
        }
        if (cardCountPos9 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card9 = Instantiate(ownedCardsMidling[8], deckPlacements);
            card9.name = "Card 9 Midling";
            cardCountPos9 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling9);
            cardCountTextPos9.text = cardCountPos9.ToString();
        }
        else return;

    }

    public void AddCardPos10ToDeck()
    {

        if (cardCountPos10 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card10 = Instantiate(ownedCardsSwarmer[9], deckPlacements);
            card10.name = "Card 10 Swarmer";
            cardCountPos10 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer10);
            cardCountTextPos10.text = cardCountPos10.ToString();
        }
        if (cardCountPos10 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card10 = Instantiate(ownedCardsIronSide[9], deckPlacements);
            card10.name = "Card 10 IronSide";
            cardCountPos10 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide10);
            cardCountTextPos10.text = cardCountPos10.ToString();
        }
        if (cardCountPos10 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card10 = Instantiate(ownedCardsMidling[9], deckPlacements);
            card10.name = "Card 10 Midling";
            cardCountPos10 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling10);
            cardCountTextPos10.text = cardCountPos10.ToString();
        }
        else return;

    }

    public void AddCardPos11ToDeck()
    {

        if (cardCountPos11 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card11 = Instantiate(ownedCardsSwarmer[10], deckPlacements);
            card11.name = "Card 11 Swarmer";
            cardCountPos11 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer11);
            cardCountTextPos11.text = cardCountPos11.ToString();
        }
        if (cardCountPos11 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card11 = Instantiate(ownedCardsIronSide[10], deckPlacements);
            card11.name = "Card 11 IronSide";
            cardCountPos11 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide11);
            cardCountTextPos11.text = cardCountPos11.ToString();
        }
        if (cardCountPos11 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card11 = Instantiate(ownedCardsMidling[10], deckPlacements);
            card11.name = "Card 11 Midling";
            cardCountPos11 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling11);
            cardCountTextPos11.text = cardCountPos11.ToString();
        }
        else return;

    }

    public void AddCardPos12ToDeck()
    {

        if (cardCountPos12 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card12 = Instantiate(ownedCardsSwarmer[11], deckPlacements);
            card12.name = "Card 12 Swarmer";
            cardCountPos12 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer12);
            cardCountTextPos12.text = cardCountPos12.ToString();
        }
        if (cardCountPos12 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card12 = Instantiate(ownedCardsIronSide[11], deckPlacements);
            card12.name = "Card 12 IronSide";
            cardCountPos12 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide12);
            cardCountTextPos12.text = cardCountPos12.ToString();
        }
        if (cardCountPos12 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card12 = Instantiate(ownedCardsMidling[11], deckPlacements);
            card12.name = "Card 12 Midling";
            cardCountPos12 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling12);
            cardCountTextPos12.text = cardCountPos12.ToString();
        }
        else return;

    }

    public void AddCardPos13ToDeck()
    {

        if (cardCountPos13 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card13 = Instantiate(ownedCardsSwarmer[12], deckPlacements);
            card13.name = "Card 13 Swarmer";
            cardCountPos13 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer13);
            cardCountTextPos13.text = cardCountPos13.ToString();
        }
        if (cardCountPos13 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card13 = Instantiate(ownedCardsIronSide[12], deckPlacements);
            card13.name = "Card 13 IronSide";
            cardCountPos13 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide13);
            cardCountTextPos13.text = cardCountPos13.ToString();
        }
        if (cardCountPos13 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card13 = Instantiate(ownedCardsMidling[12], deckPlacements);
            card13.name = "Card 13 Midling";
            cardCountPos13 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling13);
            cardCountTextPos13.text = cardCountPos13.ToString();
        }
        else return;

    }

    public void AddCardPos14ToDeck()
    {

        if (cardCountPos14 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card14 = Instantiate(ownedCardsSwarmer[13], deckPlacements);
            card14.name = "Card 14 Swarmer";
            cardCountPos14 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer14);
            cardCountTextPos14.text = cardCountPos14.ToString();
        }
        if (cardCountPos14 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card14 = Instantiate(ownedCardsIronSide[13], deckPlacements);
            card14.name = "Card 14 IronSide";
            cardCountPos14 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide14);
            cardCountTextPos14.text = cardCountPos14.ToString();
        }
        if (cardCountPos14 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card14 = Instantiate(ownedCardsMidling[13], deckPlacements);
            card14.name = "Card 14 Midling";
            cardCountPos14 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling14);
            cardCountTextPos14.text = cardCountPos14.ToString();
        }
        else return;

    }

    public void AddCardPos15ToDeck()
    {

        if (cardCountPos15 > 0 && factionChange == Faction.Swarmer && CardCountMax < 20)
        {
            GameObject card15 = Instantiate(ownedCardsSwarmer[14], deckPlacements);
            card15.name = "Card 15 Swarmer";
            cardCountPos15 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardSwarmer15);
            cardCountTextPos15.text = cardCountPos15.ToString();
        }
        if (cardCountPos15 > 0 && factionChange == Faction.IronSide && CardCountMax < 20)
        {
            GameObject card15 = Instantiate(ownedCardsIronSide[14], deckPlacements);
            card15.name = "Card 15 IronSide";
            cardCountPos15 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardIronSide15);
            cardCountTextPos15.text = cardCountPos15.ToString();
        }
        if (cardCountPos15 > 0 && factionChange == Faction.Midling && CardCountMax < 20)
        {
            GameObject card15 = Instantiate(ownedCardsMidling[14], deckPlacements);
            card15.name = "Card 15 Midling";
            cardCountPos15 -= 1;
            CardCountMax += 1;
            builtDeck.Add(cardMidling15);
            cardCountTextPos15.text = cardCountPos15.ToString();
        }
        else return;

    }


    #endregion


    #region Remove Cards from Deck

    public void RemoveCardPos1FromDeck()
    {
        if (cardCountPos1 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0 )
        {
            cardCountPos1 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 Swarmer"));
        }
        if (cardCountPos1 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos1 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 IronSide"));
        }
        if (cardCountPos1 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos1 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling1);
            cardCountTextPos1.text = cardCountPos1.ToString();
            Destroy(GameObject.Find("Card 1 Midling"));
        }
        else return;

    }

    public void RemoveCardPos2FromDeck()
    {
        if (cardCountPos2 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos2 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 Swarmer"));
        }
        if (cardCountPos2 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos2 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 IronSide"));
        }
        if (cardCountPos2 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos2 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling2);
            cardCountTextPos2.text = cardCountPos2.ToString();
            Destroy(GameObject.Find("Card 2 Midling"));
        }
        else return;

    }

    public void RemoveCardPos3FromDeck()
    {
        if (cardCountPos3 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos3 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer3);
            cardCountTextPos3.text = cardCountPos3.ToString();
            Destroy(GameObject.Find("Card 3 Swarmer"));
        }
        if (cardCountPos3 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos3 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide3);
            cardCountTextPos3.text = cardCountPos3.ToString();
            Destroy(GameObject.Find("Card 3 IronSide"));
        }
        if (cardCountPos3 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos3 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling3);
            cardCountTextPos3.text = cardCountPos3.ToString();
            Destroy(GameObject.Find("Card 3 Midling"));
        }
        else return;

    }

    public void RemoveCardPos4FromDeck()
    {
        if (cardCountPos4 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos4 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer4);
            cardCountTextPos4.text = cardCountPos4.ToString();
            Destroy(GameObject.Find("Card 4 Swarmer"));
        }
        if (cardCountPos4 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos4 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide4);
            cardCountTextPos4.text = cardCountPos4.ToString();
            Destroy(GameObject.Find("Card 4 IronSide"));
        }
        if (cardCountPos4 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos4 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling4);
            cardCountTextPos4.text = cardCountPos4.ToString();
            Destroy(GameObject.Find("Card 4 Midling"));
        }
        else return;

    }

    public void RemoveCardPos5FromDeck()
    {
        if (cardCountPos5 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos5 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer5);
            cardCountTextPos5.text = cardCountPos5.ToString();
            Destroy(GameObject.Find("Card 5 Swarmer"));
        }
        if (cardCountPos5 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos5 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide5);
            cardCountTextPos5.text = cardCountPos5.ToString();
            Destroy(GameObject.Find("Card 5 IronSide"));
        }
        if (cardCountPos5 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos5 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling5);
            cardCountTextPos5.text = cardCountPos5.ToString();
            Destroy(GameObject.Find("Card 5 Midling"));
        }
        else return;

    }

    public void RemoveCardPos6FromDeck()
    {
        if (cardCountPos6 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos6 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer6);
            cardCountTextPos6.text = cardCountPos6.ToString();
            Destroy(GameObject.Find("Card 6 Swarmer"));
        }
        if (cardCountPos6 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos6 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide6);
            cardCountTextPos6.text = cardCountPos6.ToString();
            Destroy(GameObject.Find("Card 6 IronSide"));
        }
        if (cardCountPos6 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos6 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling6);
            cardCountTextPos6.text = cardCountPos6.ToString();
            Destroy(GameObject.Find("Card 6 Midling"));
        }
        else return;

    }

    public void RemoveCardPos7FromDeck()
    {
        if (cardCountPos7 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos7 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer7);
            cardCountTextPos7.text = cardCountPos7.ToString();
            Destroy(GameObject.Find("Card 7 Swarmer"));
        }
        if (cardCountPos7 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos7 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide2);
            cardCountTextPos7.text = cardCountPos7.ToString();
            Destroy(GameObject.Find("Card 7 IronSide"));
        }
        if (cardCountPos7 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos7 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling7);
            cardCountTextPos7.text = cardCountPos7.ToString();
            Destroy(GameObject.Find("Card 7 Midling"));
        }
        else return;

    }

    public void RemoveCardPos8FromDeck()
    {
        if (cardCountPos8 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos8 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer8);
            cardCountTextPos8.text = cardCountPos8.ToString();
            Destroy(GameObject.Find("Card 8 Swarmer"));
        }
        if (cardCountPos8 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos8 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide8);
            cardCountTextPos8.text = cardCountPos8.ToString();
            Destroy(GameObject.Find("Card 8 IronSide"));
        }
        if (cardCountPos8 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos8 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling8);
            cardCountTextPos8.text = cardCountPos8.ToString();
            Destroy(GameObject.Find("Card 8 Midling"));
        }
        else return;

    }

    public void RemoveCardPos9FromDeck()
    {
        if (cardCountPos9 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos9 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer2);
            cardCountTextPos9.text = cardCountPos9.ToString();
            Destroy(GameObject.Find("Card 9 Swarmer"));
        }
        if (cardCountPos9 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos9 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide2);
            cardCountTextPos9.text = cardCountPos9.ToString();
            Destroy(GameObject.Find("Card 9 IronSide"));
        }
        if (cardCountPos9 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos9 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling9);
            cardCountTextPos9.text = cardCountPos9.ToString();
            Destroy(GameObject.Find("Card 9 Midling"));
        }
        else return;

    }

    public void RemoveCardPos10FromDeck()
    {
        if (cardCountPos10 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos10 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer10);
            cardCountTextPos10.text = cardCountPos10.ToString();
            Destroy(GameObject.Find("Card 10 Swarmer"));
        }
        if (cardCountPos10 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos10 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide10);
            cardCountTextPos10.text = cardCountPos10.ToString();
            Destroy(GameObject.Find("Card 10 IronSide"));
        }
        if (cardCountPos10 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos10 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling10);
            cardCountTextPos10.text = cardCountPos10.ToString();
            Destroy(GameObject.Find("Card 10 Midling"));
        }
        else return;

    }

    public void RemoveCardPos11FromDeck()
    {
        if (cardCountPos11 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos11 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer11);
            cardCountTextPos11.text = cardCountPos11.ToString();
            Destroy(GameObject.Find("Card 11 Swarmer"));
        }
        if (cardCountPos11 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos11 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide11);
            cardCountTextPos11.text = cardCountPos11.ToString();
            Destroy(GameObject.Find("Card 11 IronSide"));
        }
        if (cardCountPos11 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos11 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling11);
            cardCountTextPos11.text = cardCountPos11.ToString();
            Destroy(GameObject.Find("Card 11 Midling"));
        }
        else return;

    }

    public void RemoveCardPos12FromDeck()
    {
        if (cardCountPos12 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos12 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer12);
            cardCountTextPos12.text = cardCountPos12.ToString();
            Destroy(GameObject.Find("Card 12 Swarmer"));
        }
        if (cardCountPos12 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos12 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide12);
            cardCountTextPos12.text = cardCountPos12.ToString();
            Destroy(GameObject.Find("Card 12 IronSide"));
        }
        if (cardCountPos12 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos12 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling12);
            cardCountTextPos12.text = cardCountPos12.ToString();
            Destroy(GameObject.Find("Card 12 Midling"));
        }
        else return;

    }

    public void RemoveCardPos13FromDeck()
    {
        if (cardCountPos13 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos13 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer13);
            cardCountTextPos13.text = cardCountPos13.ToString();
            Destroy(GameObject.Find("Card 13 Swarmer"));
        }
        if (cardCountPos13 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos13 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide13);
            cardCountTextPos13.text = cardCountPos13.ToString();
            Destroy(GameObject.Find("Card 13 IronSide"));
        }
        if (cardCountPos13 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos13 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling13);
            cardCountTextPos13.text = cardCountPos13.ToString();
            Destroy(GameObject.Find("Card 13 Midling"));
        }
        else return;

    }

    public void RemoveCardPos14FromDeck()
    {
        if (cardCountPos14 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos14 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer14);
            cardCountTextPos14.text = cardCountPos14.ToString();
            Destroy(GameObject.Find("Card 14 Swarmer"));
        }
        if (cardCountPos14 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos14 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide14);
            cardCountTextPos14.text = cardCountPos14.ToString();
            Destroy(GameObject.Find("Card 14 IronSide"));
        }
        if (cardCountPos14 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos14 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling14);
            cardCountTextPos14.text = cardCountPos14.ToString();
            Destroy(GameObject.Find("Card 14 Midling"));
        }
        else return;

    }

    public void RemoveCardPos15FromDeck()
    {
        if (cardCountPos15 < 2 && factionChange == Faction.Swarmer && CardCountMax >= 0)
        {
            cardCountPos15 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardSwarmer15);
            cardCountTextPos15.text = cardCountPos15.ToString();
            Destroy(GameObject.Find("Card 15 Swarmer"));
        }
        if (cardCountPos15 < 2 && factionChange == Faction.IronSide && CardCountMax >= 0)
        {
            cardCountPos15 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardIronSide15);
            cardCountTextPos15.text = cardCountPos15.ToString();
            Destroy(GameObject.Find("Card 15 IronSide"));
        }
        if (cardCountPos15 < 2 && factionChange == Faction.Midling && CardCountMax >= 0)
        {
            cardCountPos15 += 1;
            CardCountMax -= 1;
            builtDeck.Remove(cardMidling15);
            cardCountTextPos15.text = cardCountPos15.ToString();
            Destroy(GameObject.Find("Card 15 Midling"));
        }
        else return;

    }



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

    }

    #endregion
}

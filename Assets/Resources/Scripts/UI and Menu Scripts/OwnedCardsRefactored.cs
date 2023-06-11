using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FactionClass
{
    Swarmer,
    Ironside,
    Midling
}

public class OwnedCardsRefactored : MonoBehaviour
{
    //prefab for the base card
    [SerializeField] GameObject cardPrefab;
    //card holders in scroll rect
    [SerializeField] FactionClass faction = FactionClass.Swarmer;
    //transform of custom deck builder
    [SerializeField] Transform customDeck;
    //a list of lists, for every owned card in every existing faction
    public List<UnitCard>[] ownedCards = new List<UnitCard>[3];
    [SerializeField]
    List<UnitCard> swarmers = new List<UnitCard>(),
        ironSide = new List<UnitCard>(),
        midling = new List<UnitCard>();
    //a list of all cards put into the deck builder
    [SerializeField] List<UnitCard> builtDeck = new List<UnitCard>();
    //list of cards in collection
    [SerializeField] private List<GameObject> cards = new List<GameObject>();


    private void Awake()
    {
        cards.Capacity = 20;
        faction = FactionClass.Swarmer;
        ownedCards = new List<UnitCard>[] { swarmers, ironSide, midling };
    }

    private void Start()
    {
        PopulateCardHolder();
    }

    private void Update()
    {
        if (builtDeck.Capacity > 20)
        {
            builtDeck.Capacity = 20;
        }

        MoveToCustomDeck();
    }

    private void MoveToCustomDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<CardContents>().doublClicked)
            {
                if (!builtDeck.Contains(cards[i].GetComponent<CardContents>().cardScriptableObject)) return;

                builtDeck[i] = Instantiate(cardPrefab, customDeck, false).GetComponent<CardContents>().cardScriptableObject;
            }
        }
    }

    private void PopulateCardHolder()
    {
        //CheckForNewCards();

        for (int i = 0; i < cards.Count; i++)
        {
            cardPrefab.GetComponent<CardContents>().cardScriptableObject = GetScriptableObjectViaFaction(i);
            cards[i] = Instantiate(cardPrefab, gameObject.transform, false);
        }
    }

    private UnitCard GetScriptableObjectViaFaction(int index)
    {
        foreach (List<UnitCard> list in ownedCards)
        {
            if (faction == list[index].factionType)
            {
                return list[index];
            }
        }

        return null;
    }

    public void ChangeFactionType()
    {
        if (faction == FactionClass.Ironside)
        {
            faction = FactionClass.Midling;
        }
        else if (faction == FactionClass.Midling)
        {
            faction = FactionClass.Swarmer;
        }
        else
        {
            faction = FactionClass.Ironside;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            Destroy(cards[i].gameObject);
        }

        PopulateCardHolder();
    }

    public void SaveBuiltDeck()
    {

    }

    private void CheckForNewCards()
    {
        List<UnitCard> newCollection = SavingHandler.Instance.UpdateCardCollection();
    }
}
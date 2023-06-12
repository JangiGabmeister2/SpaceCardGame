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
    [SerializeField] GameObject _cardPrefab;
    //card holders in scroll rect
    [SerializeField] FactionClass _faction = FactionClass.Swarmer;
    //transform of custom deck builder
    [SerializeField] Transform _customDeck;
    //a list of lists, for every owned card in every existing _faction
    public List<UnitCard>[] ownedCards = new List<UnitCard>[3];
    [SerializeField]
    List<UnitCard> _swarmers = new List<UnitCard>(),
        _ironSide = new List<UnitCard>(),
        _midling = new List<UnitCard>();
    //a list of all cards put into the deck builder
    [SerializeField] List<GameObject> _builtDeck = new List<GameObject>();
    //list of cards in collection
    [SerializeField] private List<GameObject> _cards = new List<GameObject>();


    private void Awake()
    {
        _cards.Capacity = 15;
        _builtDeck.Capacity = _customDeck.childCount;
        _faction = FactionClass.Swarmer;
        ownedCards = new List<UnitCard>[] { _swarmers, _ironSide, _midling };
    }

    //instantiates all owned cards into scroll transform at the start
    private void Start()
    {
        PopulateCardHolder();
    }

    private void Update()
    {
        if (_builtDeck.Capacity > 20)
        {
            _builtDeck.Capacity = 20;
        }

        //MoveToCustomDeck();
    }

    //private void MoveToCustomDeck()
    //{
    //    for (int i = 0; i < _cards.Count; i++)
    //    {
    //        if (_cards[i].GetComponent<CardContents>().doublClicked)
    //        {
    //            if (_builtDeck.Contains(_cards[i].gameObject)) return;
    //
    //            _builtDeck[i] = _cards[i].gameObject;
    //
    //            Destroy(_cards[i].gameObject);
    //        }
    //    }
    //}

    private void PopulateCardHolder()
    {
        //CheckForNewCards();

        for (int i = 0; i < _cards.Count; i++)
        {
            _cardPrefab.GetComponent<CardContents>().cardScriptableObject = GetScriptableObjectViaFaction(i);
            _cards[i] = Instantiate(_cardPrefab, gameObject.transform, false);
        }
    }

    private UnitCard GetScriptableObjectViaFaction(int index)
    {
        foreach (List<UnitCard> list in ownedCards)
        {
            if (_faction == list[index].factionType)
            {
                return list[index];
            }
        }

        return null;
    }

    public void ChangeFactionType()
    {
        if (_faction == FactionClass.Ironside)
        {
            _faction = FactionClass.Midling;
        }
        else if (_faction == FactionClass.Midling)
        {
            _faction = FactionClass.Swarmer;
        }
        else
        {
            _faction = FactionClass.Ironside;
        }

        for (int i = 0; i < _cards.Count; i++)
        {
            Destroy(_cards[i].gameObject);
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
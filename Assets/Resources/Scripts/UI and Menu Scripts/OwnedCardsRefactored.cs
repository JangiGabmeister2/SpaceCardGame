using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject _warning;
    [SerializeField] private Button _saveButton;
    //a list of lists, for every owned card in every existing _faction
    [Space(20)]
    public List<UnitCard>[] ownedCards = new List<UnitCard>[3];
    [SerializeField]
    List<UnitCard> _swarmers = new List<UnitCard>(),
        _ironSide = new List<UnitCard>(),
        _midling = new List<UnitCard>();
    //a list of all cards put into the deck builder
    [SerializeField] List<UnitCard> _builtDeck = new List<UnitCard>();
    //list of cards in collection
    [SerializeField] List<GameObject> _cards = new List<GameObject>();
    //UI to show the player how many cards are owned
    [SerializeField]
    private Text deckCount;

    private void Awake()
    {
        _cards.Capacity = 15;
        _builtDeck.Capacity = _customDeck.childCount;

        _faction = FactionClass.Swarmer;

        ownedCards = new List<UnitCard>[] { _swarmers, _ironSide, _midling };
    }

    private void OnEnable()
    {
        _builtDeck.Clear();

        for (int i = 0; i < _customDeck.childCount; i++)
        {
            Destroy(_customDeck.GetChild(i).gameObject);
        }
    }

    //instantiates all owned cards into scroll transform at the start
    private void Start()
    {
        PopulateCardHolder();
    }

    private void Update()
    {
        deckCount.text ="Owned Cards: " + _builtDeck.Capacity.ToString() + " / 20";
        if (_builtDeck.Capacity > 20)
        {
            _builtDeck.Capacity = 20;
        }

        if (_builtDeck.Count < 20)
        {
            _warning.SetActive(true);
            _saveButton.interactable = false;
        }
        else
        {
            _warning.SetActive(false);
            _saveButton.interactable = true;
        }

        //checks if any card has been double clicked
        for (int i = 0; i < _cards.Count; i++)
        {
            CardContents content = _cards[i].GetComponent<CardContents>();

            if (content.doublClicked)
            {
                MoveToCustomDeck(content.cardScriptableObject);

                content.doublClicked = false;
            }
        }

        for (int i = 0; i < _customDeck.childCount; i++)
        {
            CardContents content = _customDeck.GetChild(i).GetComponent<CardContents>();

            if (content.doublClicked)
            {
                _builtDeck.Remove(_builtDeck[i]);
                Destroy(_customDeck.GetChild(i).gameObject);

                content.doublClicked = false;
            }
        }
    }

    //move a specific card to deck builder
    public void MoveToCustomDeck(UnitCard unitCard)
    {
        if (_builtDeck.Count < 20)
        {
            int multiple = 0;
            for (int i = 0; i < _builtDeck.Count; i++)
            {
                if (_builtDeck[i] == unitCard)
                {
                    multiple++;
                }
            }

            if (multiple > 1)
            {
                return;
            }

            _builtDeck.Add(unitCard);

            _cardPrefab.GetComponent<CardContents>().cardScriptableObject = unitCard;
            Instantiate(_cardPrefab, _customDeck, false);
        }
    }

    //fills the card collection with cards
    private void PopulateCardHolder()
    {
        //CheckForNewCards();

        for (int i = 0; i < _cards.Count; i++)
        {
            _cardPrefab.GetComponent<CardContents>().cardScriptableObject = GetScriptableObjectViaFaction(i);
            _cardPrefab.GetComponent<CardContents>().index.text = $"{i + 1:00}";
            _cards[i] = Instantiate(_cardPrefab, gameObject.transform, false);
        }
    }

    //returns the card using its faction
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

    //when clicking change faction button, changess to next faction
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

        _builtDeck.Clear();

        for (int i = 0; i < _customDeck.childCount; i++)
        {
            Destroy(_customDeck.GetChild(i).gameObject);
        }

        PopulateCardHolder();
    }

    //saves the built deck
    public void SaveBuiltDeck()
    {
        SavingHandler.Instance.SaveChosenDeck(_builtDeck);
    }

    //whether there are new cards to be added to collection or not, must check before display collection
    private void CheckForNewCards()
    {
        List<UnitCard>[] newCollection = SavingHandler.Instance.UpdateCardCollection();

        foreach (List<UnitCard> faction in ownedCards)
        {
            foreach (UnitCard card in faction)
            {

            }
        }
    }
}
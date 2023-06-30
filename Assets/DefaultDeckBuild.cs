using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;

public class DefaultDeckBuild : MonoBehaviour
{
    public List<UnitCard> defaultDeck = new List<UnitCard>();

    private bool fullDeck = false;

    private void Update()
    {
        fullDeck = defaultDeck.Count == 20;
    }

    //gets the currently saved deck into the above list, unless it's null.
    [Button]
    private void ReloadList()
    {
        defaultDeck = SavingHandler.Instance.GetChosenDeck();
    }

    [EnableIf("fullDeck"), Button]
    private void SaveDeck()
    {
        List<UnitCard> deckToSave = new List<UnitCard>();

        foreach (UnitCard item in defaultDeck)
        {
            deckToSave.Add(item);
        }

        SavingHandler.Instance.SaveChosenDeck(deckToSave);
    }
}

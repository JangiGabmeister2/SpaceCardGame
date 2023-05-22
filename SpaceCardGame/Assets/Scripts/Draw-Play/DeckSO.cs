using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckSO", menuName = "DeckSO")]
public class DeckSO : ScriptableObject
{
    public List<BaseCard> cards;
}

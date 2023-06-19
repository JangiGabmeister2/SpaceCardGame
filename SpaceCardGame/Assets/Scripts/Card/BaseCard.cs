using UnityEngine;

public abstract class BaseCard : ScriptableObject
{
    //the basic data type for the card that both units and effects will draw from
    public string cardName;
    //the card's name
    public Sprite cardArt;
    //the card's cover art
    public int manaCost;
    //the resource cost to play a card

    public abstract void Play();
    //the basic 'play' function that all cards will use
}

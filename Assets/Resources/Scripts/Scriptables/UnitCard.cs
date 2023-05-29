using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "CardData/UnitCard")]
public class UnitCard : ScriptableObject
{
    //Card ID <faction><card num> e.g.<2><05> = 205
    public int cardID;
    //the basic data type for the card that both units and effects will draw from
    public string cardName;
    //the card's name
    public Sprite cardArt;
    //Our two options for damagetype
    public enum attackType
    {
        Kinetic, Energy
    }
    //declares what this specific spawned card's attack type is
    [SerializeField] private attackType _attackType;

    //Stats
    public int attack;
    public int cost;
    public int shield;
    //this will be the health stat that we add or subtract from
    public int hull;
    //the unit's starting health, when instantiating, make sure the 'health' int is set to this.
    public int maxHull;
    public void Play()
    {

    }
}

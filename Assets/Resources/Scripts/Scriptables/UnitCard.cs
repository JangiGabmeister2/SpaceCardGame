using UnityEngine;
using UnityEditor;

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
        Kinetic, Energy, Modular
    }
    //declares what this specific spawned card's attack type is
    [SerializeField] private attackType _attackType;

    //Stats
    public int attackDamage;
    [Tooltip("x = Base Health\ny = Max Health")]
    public Vector2 health;
    //this will be the health stat that we add or subtract from
    public int shield;
    public int resourceCost;
    [TextArea]
    public string cardDescription;

    public void Play()
    {

    }
}

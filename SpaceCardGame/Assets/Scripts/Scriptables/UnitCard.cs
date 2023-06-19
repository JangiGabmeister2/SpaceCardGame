using UnityEngine;


[CreateAssetMenu(fileName = "New Unit", menuName = "CardData/UnitCard")]
public class UnitCard : BaseCard
{
    public enum attackType
    {
        Kinetic, Energy
    }
    //Our two options for damagetype
    [SerializeField]
    private attackType thisAttack;
    //declares what this specific spawned card's attack type is
    public enum shieldType
    {
        Kinetic, Energy
    }
    //our two options for shield types
    [SerializeField]
    private shieldType thisShield;
    //declares what this specific card's shield type is

    public int attack;
    //our attack stat
    public int shield;
    //our shield stat
    public int health;
    //this will be the health stat that we add or subtract from
    public int maxHealth;
    //the unit's starting health, when instantiating, make sure the 'health' int is set to this.
    public override void Play()
    {

    }
}

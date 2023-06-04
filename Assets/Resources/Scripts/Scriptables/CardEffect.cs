using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "CardData/CardEffect")]
public class CardEffect : ScriptableObject
{
    public enum Target
    {
        Self,
        SelectedAlly,
        RandomAlly,
        AllAllies,
        SelectedEnemy,
        EnemiesAndAdjacent
    }
    public Target target;

    public enum Triggers
    {
        OnPlayed,
        Passive,
        OnAttack,
        OnTurnEnd,
        OnDeath,
        OnAllyDeath,
    }
    public Triggers trigger;

    //changes the value by a number (leave as 0 to do nothing)
    public int 
        attackChange,
        hullChange,
        shieldChange,
        costChange; //maybe change this because we don't want to affect the cost of the card itself?

    private UnitCard self;
    private UnitCard selected;

    public void ActivateEffect()
    {
        switch (target)
        {
            case Target.Self:
                ChangeValues(self);
                break;
            case Target.SelectedAlly:
                ChangeValues(selected);
                break;
            case Target.RandomAlly:
                break;
            case Target.AllAllies:
                break;
            case Target.SelectedEnemy:
                break;
            case Target.EnemiesAndAdjacent:
                break;
            default:
                break;
        }
    }
    public void ChangeValues(UnitCard card)
    {
        card.attackDamage += attackChange;
        card.hull += attackChange;
        card.shield += shieldChange;
        card.resourceCost += costChange;
    }
}

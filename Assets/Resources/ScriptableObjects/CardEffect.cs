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
        /*SelectedEnemy,
        EnemiesAndAdjacent*/
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
        costChange; //not too sure about this one chief

    private UnitCard self;
    private UnitCard selected;
    List<UnitCard> allyList;
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
            //TODO: This stuff probably needs some references to game board and play slots
            case Target.RandomAlly:
                //replace placeholder var allyList
                ChangeValues(allyList[Random.Range(0, allyList.Count - 1)]);
                break;
            case Target.AllAllies:
                foreach (UnitCard ally in allyList)
                {
                    ChangeValues(ally);
                }
                break;
            //not sure if we actually need enemy stuff
            /*case Target.SelectedEnemy:
                break;
            case Target.EnemiesAndAdjacent:
                break;*/
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
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

    public int 
        attackChange,
        HullChange,
        ShieldChange,
        CostChange;

    private UnitCard card;

    public void ActivateEffect()
    {

    }
}

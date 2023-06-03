using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    [Header("Stats")]
    [SerializeField] private attackType _attackType;
    public int attackDamage;
    //this will be the health stat that we add or subtract from
    public int hull;
    //the unit's starting health, when instantiating, make sure the 'health' int is set to this.
    public int maxHull;
    public int shield;
    public int resourceCost;
    [TextArea] public string cardDescription;
    
    #region Triggers
    //WARNING this region is where my insanity begins
    public List<CardEffect> effects;
    private UnityEvent
        onPlayed,
        passive,
        onAttack,
        onTurnEnd,
        onDeath,
        onAllyDeath;

    private void Awake()
    {
        //Looks through effects list and sets up the triggers on awake
        AddEffectsToTriggers();
    }

    /// <summary>
    /// Use this function to add a new effect to this card (when a card is out and gives other cards a buff)
    /// </summary>
    /// <param name="effect"></param>
    public void AddEffect(CardEffect effect)
    {
        //if effect is already in the list exit function
        if (effects.Contains(effect)) return;

        effects.Add(effect);
        AddEffectsToTriggers();
    }
    public void AddEffectsToTriggers()
    {
        //Adding Effect functions to UnityEvent triggers
        foreach (CardEffect effect in effects)
        {
            //uhhh adding identical listeners shouldn't cause multiple calls (hopefully)
            switch (effect.trigger)
            {
                case CardEffect.Triggers.OnPlayed:
                    onPlayed.AddListener(effect.ActivateEffect);
                    break;
                case CardEffect.Triggers.Passive:
                    passive.AddListener(effect.ActivateEffect);
                    break;
                case CardEffect.Triggers.OnAttack:
                    onAttack.AddListener(effect.ActivateEffect);
                    break;
                case CardEffect.Triggers.OnTurnEnd:
                    onTurnEnd.AddListener(effect.ActivateEffect);
                    break;
                case CardEffect.Triggers.OnDeath:
                    onDeath.AddListener(effect.ActivateEffect);
                    break;
                case CardEffect.Triggers.OnAllyDeath:
                    onAllyDeath.AddListener(effect.ActivateEffect);
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

    //Trigger functions
    public void OnPlayed() => onPlayed.Invoke();
    public void Passive() => passive.Invoke();
    public void OnAttack() => onAttack.Invoke();
    public void OnTurnEnd() => onTurnEnd.Invoke();
    public void OnDeath() => onDeath.Invoke();
    public void OnAllyDeath() => onAllyDeath.Invoke();
}
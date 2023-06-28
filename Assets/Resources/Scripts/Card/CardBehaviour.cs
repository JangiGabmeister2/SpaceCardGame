using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    
    //DO NOT CHANGE baseCard
    [SerializeField]
    internal UnitCard baseCard;
    //Making an instance of the card scriptable object (change this one)
    public UnitCard cardInstance;
    public enum CardPlayState { InDeck, Held, Played, IsDead };
    public CardPlayState cardPlayState;

    //Placeholder, grab reference from whatever is keeping track of the board later
    public List<UnitCard> allies;
    public List<UnitCard> enemies;

    private void Awake()
    {
        cardInstance = Instantiate(baseCard);
    }
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void PlayCard()
    {
        //_cardInstance.onPlayed.Invoke();
        cardInstance.OnPlayed();
    }
    void TurnEnd()
    {
        cardInstance.OnTurnEnd();
    }
    UnitCard SelectTarget(UnitCard target)
    {
        //if target card has taunt it has the priorty to be targeted
        if (target.properties.Contains(UnitCard.Property.Taunt))
        {
            //successfully target enemy with taunt
            return target;
        }

        //check if other enemies have taunt
        foreach (UnitCard enemy in enemies)
        {
            if (enemy.properties.Contains(UnitCard.Property.Taunt))
            {
                //fail to set target because a different unit has taunt and therefore priority
                return null;
            }
        }

        //if none of the other enemies have taunt
        //successfully target enemy
        return target;
    }

    void AdjacentTargetsCheck(UnitCard target)
    {
        if (target == null) return;

        int targetIndex = enemies.IndexOf(target);
        if (targetIndex - 1 >= 0)
        {
            //idk how exactly we wanna handle this information
            //like if it just changes UI and then gets called again when turn is resolving or what
        }
        if (targetIndex + 1 < enemies.Count)
        {
            //repeat for this one
        }
    }

    //TODO: Rush?
}
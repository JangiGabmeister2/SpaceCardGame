using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    
    //DO NOT CHANGE baseCard
    public UnitCard baseCard;
    //Making an instance of the card scriptable object (change this one)
    [SerializeField] private UnitCard _cardInstance;

    public UnitCard currentTarget;
    public List<UnitCard> allies;
    public List<UnitCard> enemies;
    
    void Start()
    {
        //Create instance of baseCard
        _cardInstance = Instantiate(baseCard);
    }
    void PlayCard()
    {
        //_cardInstance.onPlayed.Invoke();
        _cardInstance.OnPlayed();
    }
    void SelectCard(UnitCard target)
    {
        TargetPriorityCheck(target);
        if (target != null)
        {
            currentTarget = target;
            if (_cardInstance.properties.Contains(UnitCard.Property.Spread))
            {
                AdjacentTargetsCheck(target);
            }
        }
    }

    UnitCard TargetPriorityCheck(UnitCard target)
    {
        if (target == null) return null;
        
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
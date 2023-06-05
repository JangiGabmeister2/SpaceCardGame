using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    
    //DO NOT CHANGE baseCard
    public UnitCard baseCard;
    //Making an instance of the card scriptable object (change this one)
    [SerializeField] private UnitCard _cardInstance;
    
    void Start()
    {
        //Create instance of baseCard
        _cardInstance = Instantiate(baseCard);
    }

    void Update()
    {
        
    }
}

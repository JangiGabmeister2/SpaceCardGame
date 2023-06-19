using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    GameplayStateMachine gameplayStateMachineClass;

    [SerializeField] private int _currentXP; // Need to update this with save?
    [SerializeField] private int _XPMax;

    public bool addXP;

    // Fill bar

    public int CurrentXP
    {
        get { return _currentXP; } // This READS the current XP first.
        set
        {
            _currentXP += value; // Value, is whatever is determined below, whenever 'CurrentXP' is used
            if (_currentXP >= _XPMax)
            {
                _currentXP -= _XPMax; // if current is 11, it minuses XPMax (10) which gives the remainder
            }
        }
    }

    private void Start()
    {
        gameplayStateMachineClass = FindObjectOfType<GameplayStateMachine>();
        _XPMax = 10;

    }

    public void AddWinXP()
    {
        if (addXP)
        {
            addXP = false;
            if (gameplayStateMachineClass.gameplayState == GameplayStateMachine.GameplayState.Win && _currentXP < _XPMax)
            {
                CurrentXP = 2; // Here we are setting the value of the CurrentXP setter, which is _currentXP += value.
                CheckXP();
            }
        }
        else return;

    }
    public void AddLoseXP()
    {
        if (addXP)
        {
            addXP = false;
            if (gameplayStateMachineClass.gameplayState == GameplayStateMachine.GameplayState.Lose && _currentXP < _XPMax)
            {
                CurrentXP = 1; // Here we are setting the value of the CurrentXP setter, which is _currentXP += value.
                CheckXP();
            }
        }
        else return;

    }

    private void CheckXP()
    {

        Debug.Log(CurrentXP);
    }

}

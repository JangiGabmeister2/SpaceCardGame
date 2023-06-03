using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimationSequencer : MonoBehaviour
{
    [SerializeField, Tooltip("Order each item from starting first to last.")]
    private SequenceItem[] sequencer;

    private void Start()
    {
        var sequence = DOTween.Sequence();

        foreach (SequenceItem item in sequencer)
        {
            sequence.Append(item.transformTween);
        }
    }
}

[System.Serializable]
public struct SequenceItem
{
    public Transform uITransform;
    [SerializeField, Space(15f)] AnimationType animationType;
    [SerializeField] MoveAnimationType moveAnimationType;
    [Space(15f)] public float delayFromPrevious;

    public enum AnimationType
    {
        None,
        Move,
        Color
    }

    public enum MoveAnimationType
    {
        World_Move,
        Local_Move
    }

    public Tween transformTween
    {
        get
        {
            return null;
        }
    }
}

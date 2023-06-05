using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.ComponentModel;

public class UIAnimationSequencer : MonoBehaviour
{
    [SerializeField, Tooltip("Order each item from starting first to last.")]
    private SequenceItem[] sequencer;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (SequenceItem item in sequencer)
        {
            sequence.Append(item.uITransform.tweener);
        }
    }
}

[System.Serializable]
public class SequenceItem
{
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

    public TransformTween uITransform;
    [SerializeField, Space(15f)] AnimationType animationType;
    [SerializeField] MoveAnimationType moveAnimationType;
    [Space(15f)] public float delayFromPrevious;
}

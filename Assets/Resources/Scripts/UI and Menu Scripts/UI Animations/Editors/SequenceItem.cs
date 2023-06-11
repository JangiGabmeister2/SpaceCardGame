using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField, Space(15f)] public AnimationType animationType;
    [SerializeField] public MoveAnimationType moveAnimationType;
    [Space(15f)] public float delayFromPrevious;
}

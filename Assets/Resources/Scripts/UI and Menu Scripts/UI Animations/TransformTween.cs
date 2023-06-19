using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class TransformTween : MonoBehaviour
{
    public Tween tweener
    {
        get
        {
            return TransformTweener();
        }
    }

    public virtual Tween TransformTweener()
    {
        return null;
    }
}

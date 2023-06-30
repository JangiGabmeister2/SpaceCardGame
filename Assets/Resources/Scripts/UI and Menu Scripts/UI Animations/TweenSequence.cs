using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using DG.Tweening;

public class TweenSequence : MonoBehaviour
{
    public UnityEvent onComplete;

    [SerializeField] TransformTween[] tweens;

    private void Start()
    {
        Sequence s = DOTween.Sequence();

        for (int i = 0; i < tweens.Length; i++)
        {
            s.Append(tweens[i].tweener);
        }

        s.OnComplete(onComplete.Invoke);
    }
}

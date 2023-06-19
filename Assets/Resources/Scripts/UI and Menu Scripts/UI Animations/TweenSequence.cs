using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenSequence : MonoBehaviour
{
    [SerializeField] TransformTween[] tweens;

    private void Start()
    {
        Sequence s = DOTween.Sequence();

        for (int i = 0; i < tweens.Length; i++)
        {
            s.Append(tweens[i].tweener);
        }
    }
}

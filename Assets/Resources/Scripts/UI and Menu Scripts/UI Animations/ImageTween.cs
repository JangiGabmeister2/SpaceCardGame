using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTween : TransformTween
{
    public override Tween TransformTweener()
    {
        Sequence s = DOTween.Sequence();

        Tween tween = s.Append(transform.DOLocalMoveX(transform.localPosition.x, 5f));

        return tween;
    }
}

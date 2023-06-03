using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundTween : TransformTween
{
    private Vector2 fade;

    public override Tween TransformTweener()
    {
        Sequence s = DOTween.Sequence();

        s.Append(DOTween.To(() => fade, x => fade = x, new Vector2(0, 484), .5f));

        return s;
    }

    private void Start()
    {
        fade = new Vector2(0, 5000);
        Sequence s = DOTween.Sequence();

        s.Append(transform.DOScale(new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f), 50f)
            .SetDelay(2f)
            .SetEase(Ease.InSine)
            .SetLoops(-1, LoopType.Yoyo));
    }

    private void Update()
    {
        transform.GetComponent<RectMask2D>().softness = Vector2Int.RoundToInt(fade);
    }
}

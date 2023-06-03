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
        Tween tween = DOTween.To(() => fade, x => fade = x, new Vector2(0, 484), .5f);

        return tween;
    }

    private void Start()
    {
        fade = new Vector2(0, 5000);
    }

    private void Update()
    {
        transform.GetComponent<RectMask2D>().softness = Vector2Int.RoundToInt(fade);
    }
}

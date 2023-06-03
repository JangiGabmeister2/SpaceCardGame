using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTween : TransformTween
{
    [SerializeField] Color mainShown, mainFaded, shadowShown, shadowFaded, outlineShown, outlineFaded;

    private void Start()
    {
        transform.GetComponent<Text>().color = mainFaded;
        transform.GetComponent<Shadow>().effectColor = shadowFaded;
        transform.GetComponent<Outline>().effectColor = outlineFaded;
    }

    public override Tween TransformTweener()
    {
        Sequence s = DOTween.Sequence();

        Tween tween = s.Append(transform.DOLocalMoveY(transform.localPosition.y + 10f, 2f));
        s.Join(transform.GetComponent<Text>().DOColor(mainShown, 2f));

        return tween;
    }
}

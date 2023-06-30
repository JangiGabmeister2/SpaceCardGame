using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTween : TransformTween
{
    [SerializeField] Color mainShown, mainFaded, shadowShown, shadowFaded, outlineShown, outlineFaded;

    private void Start()
    {
        transform.GetComponentInChildren<Text>().color = mainFaded;
        transform.GetComponentInChildren<Shadow>().effectColor = shadowFaded;
        transform.GetComponentInChildren<Outline>().effectColor = outlineFaded;
    }

    public override Tween TransformTweener()
    {
        Sequence s = DOTween.Sequence();

        Tween tween = s.Append(transform.DOLocalMoveY(transform.localPosition.y + 10f, .5f))
            .Join(transform.GetComponentInChildren<Text>().DOColor(mainShown, .5f));

        return tween;
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTween : TransformTween, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color mainShown, mainFaded, shadowShown, shadowFaded, outlineShown, outlineFaded;
    [SerializeField] Image highlight;

    [SerializeField] Color highlightFaded, highlightShown;

    private bool buttonsShowUp;

    private void Start()
    {
        transform.GetComponentInChildren<Text>().color = mainFaded;
        transform.GetComponentInChildren<Shadow>().effectColor = shadowFaded;
        transform.GetComponentInChildren<Outline>().effectColor = outlineFaded;
    }

    private void Update()
    {
        buttonsShowUp = transform.GetComponentInChildren<Text>().color == mainShown;
    }

    public override Tween TransformTweener()
    {
        Sequence s = DOTween.Sequence();

        Tween tween = s.Append(transform.DOLocalMoveY(transform.localPosition.y + 10f, .5f))
            .Join(transform.GetComponentInChildren<Text>().DOColor(mainShown, .5f));

        return tween;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonsShowUp)
        {
            highlight.color = highlightShown;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonsShowUp)
        {
            highlight.color = highlightFaded;
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PanelTweener : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent onPanelExit;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayTweenOut();
    }

    public void PlayTweenIn()
    {
        transform.localPosition = new Vector2(0f, -1000f);
        transform.DOLocalMove(new Vector2(0f, 0f), .5f)
            .SetEase(Ease.InOutBack);
    }

    public void PlayTweenOut()
    {
        transform.localPosition = new Vector2(0f, 0f);
        transform.DOLocalMove(new Vector2(0f, -1000f), .5f)
            .SetEase(Ease.InOutBack)
            .OnComplete(onPanelExit.Invoke);
    }
}

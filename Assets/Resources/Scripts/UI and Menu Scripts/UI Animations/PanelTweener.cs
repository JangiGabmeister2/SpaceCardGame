using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTweener : MonoBehaviour
{
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
            .SetEase(Ease.InOutBack);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTweener : MonoBehaviour
{
    public void PlayTweenIn()
    {
        transform.DOLocalMoveY(transform.localPosition.y + -transform.localPosition.y, 3f).SetEase(Ease.InOutElastic);
    }

    public void PlayTweenOut()
    {
        transform.DOLocalMoveY(transform.localPosition.y + -transform.localPosition.y, 3f).SetEase(Ease.InOutBack).Flip();        
    }
}

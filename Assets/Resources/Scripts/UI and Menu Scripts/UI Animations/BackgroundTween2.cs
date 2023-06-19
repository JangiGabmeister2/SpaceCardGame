using DG.Tweening;
using UnityEngine;

public class BackgroundTween2 : MonoBehaviour
{
    public void Start()
    {
        Sequence s = DOTween.Sequence();
        
        s.Append(transform.DOScale(new Vector3(transform.localScale.x * 4, transform.localScale.y * 4), 5f).SetLoops(-1, LoopType.Yoyo));        
    }
}

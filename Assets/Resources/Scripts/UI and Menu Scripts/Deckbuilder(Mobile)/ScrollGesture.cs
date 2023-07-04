using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollGesture : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public ScrollRect thisScrollRect;
    public Scrollbar thisScrollBar;

    public Vector2 swipeOrigin;
    private float scrollOrigin;

    private void Awake()
    {
        thisScrollRect = GetComponent<ScrollRect>();
        thisScrollBar = GetComponentInChildren<Scrollbar>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        swipeOrigin = eventData.position;
        Debug.Log("Swipe Origin = " + swipeOrigin.ToString());
        scrollOrigin = thisScrollBar.value;
    }
    public void OnDrag(PointerEventData eventData)
    {
        float swipeDistance = eventData.position.x - swipeOrigin.x;
        float contentWidth = thisScrollRect.content.rect.width;
        float viewPortWidth = thisScrollRect.viewport.rect.width;

        float normalizedSwipeDist = swipeDistance / (contentWidth - viewPortWidth);

        thisScrollBar.value = Mathf.Clamp(scrollOrigin + normalizedSwipeDist, 0f, 1f);

    }
}

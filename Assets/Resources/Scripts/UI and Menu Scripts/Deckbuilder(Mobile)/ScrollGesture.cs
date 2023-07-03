using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollGesture : MonoBehaviour
{
    #region Speed and Deadzones
    public float swipeThreshold = 100f;
    public float scrollSpeed = 10f;
    #endregion
    #region  Scrollrect and Bools
    [SerializeField]
    private ScrollRect thisScrollRect;
    private bool isDragging = false; // whether the current action is a drag or not
    private Vector2 dragStartPos; //where is the first point of contact the device has registered
    #endregion

    private void Awake()
    {
        thisScrollRect = GetComponent<ScrollRect>();   
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = false;
        dragStartPos = eventData.position;  
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragDelta = eventData.position - dragStartPos;
        if(!isDragging && dragDelta.magnitude > swipeThreshold)
        {
            thisScrollRect.OnBeginDrag(eventData);
        }
        if (isDragging)
        {
            thisScrollRect.OnDrag(eventData);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            thisScrollRect.OnEndDrag(eventData);
        }
        isDragging = false;
    }
}

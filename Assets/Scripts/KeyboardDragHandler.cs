﻿using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardDragHandler : MonoBehaviour, IDragHandler
{
    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
    }

    #endregion IDragHandler implementation
}
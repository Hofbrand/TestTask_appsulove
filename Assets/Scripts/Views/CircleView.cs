using Assets.Scripts.Controllers;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleView : MonoBehaviour, IPointerClickHandler
{
    public Action OnCircleClicked;
    //private CircleController controller;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnCircleClicked.Invoke();
    }

    public void UpdatePosition(Vector2 currentPosition)
    {
        transform.position = currentPosition;
    }
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class CircleView : BaseView, IPointerClickHandler
    {
        [SerializeField] public float Speed;

        public Action OnCircleClicked;
       
        public void OnPointerClick(PointerEventData eventData)
        {
            OnCircleClicked.Invoke();
        }

        public void UpdatePosition(Vector2 currentPosition)
        {
            transform.position = currentPosition;
        }
    }
}

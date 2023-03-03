using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class InputManager
    {
        public Vector2 GetTouchPosition()
        {

            return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        public List<Vector2> GetTouches() 
        {
            var _touchPositions = new List<Vector2>();
            Vector2 _startTouchPosition;
            Vector2 _lastTouchPosition = Vector2.zero;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
                _lastTouchPosition = touch.position;
                _touchPositions.Clear();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - _lastTouchPosition;
                _touchPositions.Add(delta);
                _lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 delta = touch.position - _lastTouchPosition;
                _touchPositions.Add(delta);
                _lastTouchPosition = touch.position;

            }

            return _touchPositions;
        }
    }
}
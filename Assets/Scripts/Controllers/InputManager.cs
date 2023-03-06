using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class InputManager
    {
        private Action<List<Vector2>> onInputHandled;

        public List<Vector2> TouchPositions = new();

        private Vector2 GetTouchPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        public InputManager(CircleController circleController)
        {
            onInputHandled += circleController.StartMovement;
        }

        public void HandleInput(float deltaTIme)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    TouchPositions.Clear();
                    TouchPositions.Add(GetTouchPosition());
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                   TouchPositions.Add(GetTouchPosition());
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    onInputHandled.Invoke(TouchPositions);
                }
            }

        }
    }
}
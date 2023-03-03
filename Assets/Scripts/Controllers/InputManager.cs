using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers
{
    public class InputManager
    {
        public Vector2 GetTouchPosition()
        {
#if UNITY_EDITOR
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
            return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
        }
    }
}
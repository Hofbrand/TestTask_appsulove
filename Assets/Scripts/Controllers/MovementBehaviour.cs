using UnityEngine;

namespace Controllers
{
    public class MovementBehaviour
    {
        public Vector2 Move(Vector2 currentPosition, float deltaTime, Vector2 target, float speed)
        {
            return Vector2.MoveTowards(currentPosition, target, speed * deltaTime); 
        }
    }
}
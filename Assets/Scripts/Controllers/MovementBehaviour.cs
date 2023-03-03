using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MovementBehaviour
    {
        private float speed;
     
        public MovementBehaviour(float speed)
        {
            this.speed = speed;
        }

        public Vector2 Move(Vector2 currentPosition, float deltaTime, Vector2 target)
        {
            return Vector2.MoveTowards(currentPosition, target, speed * deltaTime); ;
        }
    }
}
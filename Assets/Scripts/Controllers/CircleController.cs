using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Controllers
{
    public class CircleController
    {
        private CircleModel circleModel;
        private CircleView circleView;
        private MovementBehaviour moveBehaviour;
        private float speed = 5f;
       

        public CircleController(CircleModel model, CircleView view)
        {
            circleModel = model;
            circleView = view;
            moveBehaviour = new MovementBehaviour(speed);
            view.OnCircleClicked += Stop;
        }

        public void MoveCircle( float deltaTime)
        {
            if (!circleModel.IsMoving)
            {
                circleModel.Target = null;
                circleModel.IsMoving = true;
            }

            if (circleModel.Target != null)
            {
                var currentPosition = moveBehaviour.Move(circleView.transform.position, deltaTime, circleModel.Target.Value);
                circleModel.SetCurrentPosition(currentPosition);
                circleView.UpdatePosition(currentPosition);
            }
           
        }

        public void StartMovemnt(Vector2 newTarget)
        {
            circleModel.Target = newTarget;
            circleModel.IsMoving = true;
        }

        public void Stop()
        {
            Debug.Log("Stop");
            circleModel.Target = null;
        }
    }
}



using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Controllers
{
    public class CircleController
    {
        private CircleModel circleModel;
        private CircleView circleView;
        private MovementBehaviour moveBehaviour;
        private ScoreManager scoreManager;
        private float speed = 5f;
       

        public CircleController(CircleModel model, CircleView view, ScoreManager score)
        {
            circleModel = model;
            circleView = view;
            scoreManager = score;
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
            //if(circleModel.Targets != null && circleModel.Target == null)
            //{
            //    circleModel.Target = circleModel.Targets[0];
            //}
            if (circleModel.Target != null)
            {

                var previousPosition = circleView.transform.position;
                var currentPosition = moveBehaviour.Move(circleView.transform.position, deltaTime, circleModel.Target.Value);
                circleModel.SetCurrentPosition(currentPosition);
              
                Debug.LogError(scoreManager);
                Debug.Log(previousPosition);

                scoreManager.AddDistance(Vector2.Distance(previousPosition, currentPosition));
                circleView.UpdatePosition(currentPosition);

                //if (currentPosition == circleModel.Target && circleModel.Targets != null)
                //{
                //    circleModel.Target = null;
                //    circleModel.Targets.RemoveAt(0);
                //}
            }
        }

        public void StartMovement(Vector2 newTarget)
        {
            circleModel.Distance = Vector2.Distance(newTarget, circleView.transform.position);
            circleModel.Target = newTarget;
            circleModel.IsMoving = true;
        }

        public void StartMovement(List<Vector2> targets)
        {
            circleModel.Targets = targets;
            circleModel.IsMoving = true;
        }

        public void Stop()
        {
            Debug.Log("Stop");
            circleModel.Target = null;
            if(circleModel.Targets != null)
            {
                circleModel.Targets.Clear();
            }
        }
    }
}



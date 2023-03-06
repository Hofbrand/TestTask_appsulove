using Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Controllers
{
    public class CircleController : BaseController <CircleModel, CircleView>
    {
        public Action<float> OnPositionChanged;
        private MovementBehaviour moveBehaviour;
        private float speed = 3f;
       
        public CircleController(CircleModel model, CircleView view) : base(model, view) 
        {
            moveBehaviour = new MovementBehaviour(speed);
            view.OnCircleClicked += Stop;
        }

        public void StartMovement(List<Vector2> targets)
        {
            model.Targets = targets;
            model.IsMoving = true;
        }

        private void MoveCircle(float deltaTime)
        {
            if (!model.IsMoving)
            {
                model.Target = null;
                model.IsMoving = true;
            }
            if (model.Targets != null && model.Targets.Count > 0 && model.Target == null)
            {
                model.Target = model.Targets[0];
            }
            if (model.Target != null)
            {
                var previousPosition = view.transform.position;
                var currentPosition = moveBehaviour.Move(view.transform.position, deltaTime, model.Target.Value);
                view.UpdatePosition(currentPosition);
                OnPositionChanged.Invoke(Vector2.Distance(previousPosition, currentPosition));

                if (currentPosition == model.Target && model.Targets != null)
                {
                    model.Targets.RemoveAt(0);
                    if (model.Targets.Count > 0)
                    {
                        model.Target = model.Targets[0];
                    }
                    else
                    {
                        model.Target = null;
                    }
                }
            }
        }

        public void Stop()
        {
            model.Target = null;
            if(model.Targets != null)
            {
                model.IsMoving = false;
                model.Targets.Clear();
            }
        }

        public void Update(float deltaTime)
        {
            MoveCircle(deltaTime);
        }
    }
}



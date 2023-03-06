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

        public CircleController(CircleModel model, CircleView view) : base(model, view) 
        {
            moveBehaviour = new MovementBehaviour();
            model.MaxSpeed = view.Speed;
            view.OnCircleClicked += Stop;
        }

        public void StartMovement(List<Vector2> targets)
        {
            model.Targets = targets;
            model.IsMoving = true;
        }

        private void MoveCircle(float deltaTime)
        {     

            if (model.IsMoving && model.Targets != null && model.Targets.Count > 0 && model.Target == null)
            {
                model.ElapsedDistance = 0;
                model.Target = model.Targets[0];
                CountTotalDistance();
            }

            if (model.Target != null)
            {
              
                var previousPosition = view.transform.position;
                var currentPosition = moveBehaviour.Move(view.transform.position, deltaTime, model.Target.Value, GetSpeed(model.ElapsedDistance));
                OnPositionChanged.Invoke(Vector2.Distance(previousPosition, currentPosition));
                model.ElapsedDistance += Vector2.Distance(previousPosition, currentPosition);

                view.UpdatePosition(currentPosition);

                if (Vector2.Distance(currentPosition, model.Target.Value) < 0.1f && model.Targets != null)
                {
                    model.Targets.RemoveAt(0);
                    if (model.Targets.Count > 0)
                    {
                        model.Target = model.Targets[0];
                    }
                    else
                    {
                        model.Target = null;
                        model.IsMoving = false;
                    }
                }
            }
        }

        private void CountTotalDistance()
        {
            model.TotalDistance = 0;
            model.TotalDistance += Vector2.Distance(view.transform.position, model.Target.Value);

            for (int i = 0; i < model.Targets.Count - 1; i++)
            {
                model.TotalDistance += Vector2.Distance(model.Targets[i], model.Targets[i + 1]);
            }   
        }

        private float GetSpeed(float elapsedDistance)
        {
            if (elapsedDistance <= model.TotalDistance / 2f)
            {
                return  Mathf.Lerp( 0.2f , model.MaxSpeed, elapsedDistance / model.TotalDistance * 2f);
            }
            else
            {
                return  Mathf.Lerp( model.MaxSpeed, 0.2f, (elapsedDistance - model.TotalDistance / 2f) / model.TotalDistance * 2f);
            }
        }

        public void Stop()
        {
            model.Target = null;
            model.IsMoving = false;
            model.Targets.Clear();
        }

        public void Update(float deltaTime)
        {
            MoveCircle(deltaTime);
        }
    }
}



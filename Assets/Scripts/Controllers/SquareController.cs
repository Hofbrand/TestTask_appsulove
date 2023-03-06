using Models;
using System;
using UnityEngine;
using Views;

namespace Controllers
{
    public class SquareController : BaseController<SquareModel, SquareView>
    {
        public Action<GameObject> OnDestroy;

        public SquareController(SquareModel model, SquareView view) : base(model, view)
        {
            view.OnCollision += Destroy;
        }

        private void Destroy()
        {
            OnDestroy.Invoke(view.gameObject);
        }
    }
}


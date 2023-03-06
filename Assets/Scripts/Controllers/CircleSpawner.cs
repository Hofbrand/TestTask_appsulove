using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class CircleSpawner : AbstractSpawner<CircleController, CircleView, CircleModel>
    {
        protected override CircleController CreateController(CircleView view)
        {
            return new CircleController(new CircleModel(), view);
        }

        protected override GameObject GetSpawnObjectFromStorage()
        {
            return storage.CirclePrefab;
        }
    }
}

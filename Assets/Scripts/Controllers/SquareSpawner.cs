using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class SquareSpawner : AbstractSpawner<SquareController, SquareView, SquareModel>
    {
        [SerializeField] private SquareView view;
        [SerializeField] private int spawnDelay;
        [SerializeField] private int points;
        [SerializeField] private int maxSquares = 10;

        public System.Action<int> OnDestroySquare;

        protected override bool SpawnFilter()
        {
            if (gameObjects.Count - 1 >= maxSquares)
                return false;

            return true;
        }

        public void SpawnSquares()
        {
            InvokeRepeating(nameof(Spawn), spawnDelay, spawnDelay);
        }

        public void RemoveFromList(GameObject go)
        {
            OnDestroySquare.Invoke(points);
            gameObjects.Remove(go.transform);
        }

        protected override SquareController CreateController(SquareView view)
        {
            var square = new SquareController(new SquareModel(), view);
            square.OnDestroy += RemoveFromList;
            return square;
        }

        protected override GameObject GetSpawnObjectFromStorage()
        {
            return storage.SquarePrefab;
        }
    }
}


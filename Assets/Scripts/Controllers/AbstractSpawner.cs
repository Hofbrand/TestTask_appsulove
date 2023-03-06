using Models;
using Views;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public abstract class AbstractSpawner<TController, TView, TModel> : MonoBehaviour 
        where TController : BaseController <TModel, TView>
        where TView : IView
        where TModel : BaseModel
    {
        [SerializeField] protected PrefabsStorage storage;
        [SerializeField] private float spawnOffset;

        protected List<Transform> gameObjects = new();
        protected float screenWidth;
        protected float screenHeight;
        protected abstract TController CreateController(TView view);
        protected abstract GameObject GetSpawnObjectFromStorage();

        private void Start()
        { 
            screenHeight = Camera.main.orthographicSize * 2f;
            screenWidth = screenHeight * Screen.width / Screen.height;
        }

        public virtual TController Spawn()
        {
            if (SpawnFilter())
            {
                var instance = CreateInstance();
                TView view = instance.GetComponent<TView>();
                var controller = CreateController(view);
                gameObjects.Add(instance.transform);

                return controller;
            }

            return null;
        }

        private GameObject CreateInstance()
        {
            var prefab = GetSpawnObjectFromStorage();
            var position = GetRandomPosition();
            return Instantiate(prefab, position, Quaternion.identity);
        }

        private Vector2 GetRandomPosition()
        {
            float x = Random.Range(-screenWidth / 2f + spawnOffset, screenWidth / 2f - spawnOffset);
            float y = Random.Range(-screenHeight / 2f + spawnOffset, screenHeight / 2f - spawnOffset);
            return PositionFilter(new Vector2(x, y));
        }

        protected virtual bool SpawnFilter()
        {
            return true;
        }

        private Vector2 PositionFilter(Vector2 vector2)
        {
            while (IsPositionOccupied(vector2))
            {
                vector2 = GetRandomPosition();
            }

            return vector2;
        }

        private bool IsPositionOccupied(Vector2 position)
        {
            foreach (var transform in gameObjects)
            {
                if (Vector2.Distance(transform.position, position) < spawnOffset)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

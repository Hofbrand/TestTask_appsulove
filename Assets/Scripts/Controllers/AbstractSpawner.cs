using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public abstract class AbstractSpawner<T> : MonoBehaviour where T : Object
    {
        private float screenWidth;
        private float screenHeight;

        private void Start()
        {
            screenHeight = Camera.main.orthographicSize * 2f;
            screenWidth = screenHeight * Screen.width / Screen.height;
        }

        public T Spawn(T objectToSpawn)
        {
            if (SpawnFilter())
            {
                return IncreaseAmount(CreateInstance(objectToSpawn, GetRandomPosition()));
            }

            return null;
        }

        private T CreateInstance(T objectToSpawn, Vector3 spawnPosition) 
        {
            return Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }

        protected virtual bool SpawnFilter()
        {
            return true;
        }

        protected virtual T IncreaseAmount(T go) { return go; }

        protected Vector2 GetRandomPosition()
        {

            float x = Random.Range(-screenWidth / 2f + 1/ 2f, screenWidth / 2f - 1/ 2f);
            float y = Random.Range(-screenHeight / 2f + 1 / 2f, screenHeight / 2f - 1/ 2f);
            return PositionFilter(new Vector2(x, y));
        }

        protected virtual Vector2 PositionFilter(Vector2 vector2)
        {
            return vector2;
        }
    }
}

using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public abstract class AbstractSpawner<T> : MonoBehaviour where T : Object
    {
        public T Spawn(T objectToSpawn, Vector3 spawnPosition)
        {
            return Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}

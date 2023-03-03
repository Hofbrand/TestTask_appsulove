using Assets.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PrefabsStorage storage;
    private AbstractSpawner<GameObject> circleSpawner;
    private AbstractSpawner<GameObject> squareSpawner;

    void Start()
    {
        circleSpawner = GetComponent<CircleSpawner>();
        circleSpawner.Spawn(storage.CirclePrefab, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

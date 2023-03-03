using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsStorage", menuName = "ScriptableObjects/PrefabData", order = 1)]
public class PrefabsStorage : ScriptableObject
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private GameObject circlePrefab;

    public GameObject SquarePrefab { get { return squarePrefab; } }
    public GameObject CirclePrefab { get { return circlePrefab; } }
}

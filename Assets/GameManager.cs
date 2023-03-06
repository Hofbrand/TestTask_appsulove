using Controllers;
using Views;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;
    private Action<float> OnUpdate;

    private SaveLoadSystem saveLoadSystem;
    private InputManager input;
    private ScoreManager score;
 
    void Start()
    {
        InitGame(); 
    }

    private void InitGame()
    {  
        CircleSpawner circleSpawner = GetComponent<CircleSpawner>();
        CircleController circleController = circleSpawner.Spawn();
        SquareSpawner squareSpawner = GetComponent<SquareSpawner>();
        squareSpawner.SpawnSquares();

        score = new ScoreManager(scoreView);
        input = new InputManager(circleController);
        saveLoadSystem = new SaveLoadSystem();

        OnUpdate += input.HandleInput;
        OnUpdate += circleController.Update;
        circleController.OnPositionChanged += score.UpdateDistance;
        squareSpawner.OnDestroySquare += score.UpdatePoints;

        saveLoadSystem.OnDataLoaded += score.UpdateData;
        score.OnDataChanged = saveLoadSystem.SaveData;
     
        saveLoadSystem.LoadData();
    }

    private void Update()
    {
        OnUpdate.Invoke(Time.deltaTime);
    }
}

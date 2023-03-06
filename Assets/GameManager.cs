using Controllers;
using Views;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;

    private Action<float> onUpdate;
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

        onUpdate += input.HandleInput;
        onUpdate += circleController.Update;
        circleController.OnPositionChanged += score.UpdateDistance;
        squareSpawner.OnDestroySquare += score.UpdatePoints;
        saveLoadSystem.OnDataLoaded += score.UpdateData;
        score.OnDataChanged = saveLoadSystem.SaveData;
     
        saveLoadSystem.LoadData();
    }

    private void Update()
    {
        onUpdate.Invoke(Time.deltaTime);
    }
}

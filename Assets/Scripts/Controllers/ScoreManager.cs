using Assets.Scripts.Views;
using System;
using UnityEngine;

public class ScoreManager
{
    public Action<int> OnScoreChanged;
    public Action<float> OnDistanceChanged;
    private int _score = 0;
    private float _distance = 0;
    private ScoreView scoreView;

    public ScoreManager(ScoreView view) 
    {
        scoreView = view;
        OnScoreChanged += scoreView.UpdateScore;
        OnDistanceChanged += scoreView.UpdateDistance;
        OnDistanceChanged.Invoke(0);
        OnScoreChanged.Invoke(0);
    }
    public void AddPoints(int points)
    {
        Debug.LogError("points" + points);
        _score += points;
        OnScoreChanged.Invoke(_score);
    }

    public void AddDistance(float distance)
    {
        _distance += distance;
        OnDistanceChanged.Invoke(_distance);
    }

    internal float GetDistance()
    {
        return _distance;
    }

    internal int GetPoints()
    {
        return _score;
    }
}
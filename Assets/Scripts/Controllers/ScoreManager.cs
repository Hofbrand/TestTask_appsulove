using Assets.Scripts.Views;
using System;
using UnityEngine;

public class ScoreManager
{
    public Action<int> OnScoreChanged;
    private int _score = 0;
    private ScoreView scoreView;

    public ScoreManager(ScoreView view) 
    {
        scoreView = view;
        OnScoreChanged += scoreView.UpdateScore;
        OnScoreChanged.Invoke(0);
    }
    public void AddPoints(int points)
    {
        Debug.LogError("points" + points);
        _score += points;
        OnScoreChanged.Invoke(_score);
    }
}
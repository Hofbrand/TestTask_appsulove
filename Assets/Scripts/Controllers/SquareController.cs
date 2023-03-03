using System;
using UnityEngine;

public class SquareController 
{
    public Action<GameObject> OnDestroy;
    private SquareView view;
    private SquareModel model;
    private ScoreManager score;

    public SquareController(SquareView view, SquareModel model, ScoreManager scoreManager)
    {
        this.view = view;
        this.model = model;
        this.score = scoreManager;
        view.OnCollision += Destroy;
    }

    private void Destroy()
    {
        score.AddPoints(model.Points);
        OnDestroy.Invoke(view.gameObject);
    }

}

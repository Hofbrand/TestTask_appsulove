using System;
using System.Collections.Generic;
using UnityEngine;

public class CircleModel 
{
    private Vector2 currentPosition;
    public bool IsMoving { get; set; }
    public Vector2? Target { get; set; }
    public List<Vector2> Targets { get; set; }
    public float Distance { get; internal set; }

    public void SetCurrentPosition(Vector2 newPosition)
    {
        currentPosition = newPosition;
    }

}

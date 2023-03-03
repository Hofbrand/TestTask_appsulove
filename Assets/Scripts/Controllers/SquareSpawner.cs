using Assets.Scripts.Controllers;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : AbstractSpawner<GameObject>
{
    private int squaresCount = 0;
    private readonly int maxSquares = 10;
    private List<GameObject> squares = new List<GameObject>();

    protected override bool SpawnFilter()
    {
        Debug.LogError("SpawnFilter " + squaresCount + " " + maxSquares);
        if (squaresCount >= maxSquares)
            return false;

        return true;
    }

    protected override GameObject IncreaseAmount(GameObject go)
    {
        squaresCount++;
        squares.Add(go);
        return base.IncreaseAmount(go);
    }

    protected override Vector2 PositionFilter(Vector2 vector2)
    {
        while ( IsPositionOccupied(vector2))
        {
            vector2 = GetRandomPosition();
        }

        return vector2;
    }

    private bool IsPositionOccupied(Vector2 position)
    {
        foreach (GameObject square in squares)
        {
            if (Vector2.Distance(square.transform.position, position) < 1f)
            {
                return true;
            }
        }
        return false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareView : MonoBehaviour
{
    public Action OnCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CircleView>())
        {
            OnCollision.Invoke();
            Destroy(gameObject);
        }
    }
}

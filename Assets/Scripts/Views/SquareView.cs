using System;
using UnityEngine;

namespace Views
{
    public class SquareView : BaseView
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
}
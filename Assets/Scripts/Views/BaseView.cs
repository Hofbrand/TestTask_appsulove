using UnityEngine;

namespace Views
{
    public interface IView
    {
        void Destroy();
    }

    public abstract class BaseView : MonoBehaviour, IView
    {
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}


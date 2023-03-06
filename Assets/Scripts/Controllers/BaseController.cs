using Models;
using Views;

namespace Controllers
{
    public abstract class BaseController <M,V>
        where M : BaseModel
        where V : IView
    {
        protected M model;
        protected V view;

        public BaseController(M model, V view)
        {
            this.model = model;
            this.view = view;
        }
    }
}

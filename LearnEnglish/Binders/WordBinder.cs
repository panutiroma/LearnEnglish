using System.Web.Mvc;

namespace LearnEnglish.Binders
{
    public class WordBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
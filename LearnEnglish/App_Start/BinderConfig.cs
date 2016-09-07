using Domain;
using LearnEnglish.Binders;
using System.Web.Mvc;

namespace LearnEnglish.App_Start
{
    internal class BinderConfig
    {
        public static void RegisterBinders(ModelBinderDictionary modelBinders)
        {
            modelBinders.Add(typeof(Word), new WordBinder());
        }
    }
}
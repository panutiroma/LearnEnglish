using Ninject;
using Repository;
using Repository.Interfaces;

namespace Infrastructure
{
    internal static class ServiceLocator
    {
        #region Public static members

        public static void RegisterAll()
        {
            Kernel.Bind<IWordRepository>()
               .To<WordRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion

        #region Non-public static members

        private static readonly IKernel Kernel = new StandardKernel();

        #endregion
    }
}

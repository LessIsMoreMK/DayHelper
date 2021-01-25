using Ninject;

namespace DayHelper
{
    public static class IoC
    {
        #region Public Properties

        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static ApplicationViewModel Application { get; set; } = IoC.Get<ApplicationViewModel>();

        #endregion

        #region Construction

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
using System;
using System.Windows;

namespace DayHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ChangeTheme(Uri uri)
        {
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            // Bind UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }

    }
}

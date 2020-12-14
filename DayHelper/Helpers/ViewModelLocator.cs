
namespace DayHelper
{
    /// <summary>
    /// Locates view model from the IoC for use in binding in xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        #endregion
    }
}

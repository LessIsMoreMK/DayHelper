using System;
using System.Diagnostics;
using System.Globalization;

namespace DayHelper
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Task:
                    return new TaskPage();

                case ApplicationPage.Lists:
                    return new ListsPage();

                case ApplicationPage.Finished:
                    return new FinishedPage();

                case ApplicationPage.Deleted:
                    return new DeletedPage();

                case ApplicationPage.Analyze:
                    return new AnalyzePage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

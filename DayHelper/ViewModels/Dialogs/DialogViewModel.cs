using System.Windows;
using System.Windows.Controls;

namespace DayHelper
{
    public class DialogViewModel : WindowViewModel
    {
        #region Public Properties
        public string Title { get; set; }

        public Control Content { get; set; }
        #endregion

        #region Constructor
        public DialogViewModel(Window window) : base(window)
        {
            // Make title bar smaller
            TitleHeight = 30;
        }
        #endregion
    }
}
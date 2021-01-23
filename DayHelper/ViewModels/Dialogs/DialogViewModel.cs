using System.Windows;
using System.Windows.Controls;

namespace DayHelper
{
    public class DialogViewModel : WindowViewModel
    {
        #region Public Properties

        public string Title { get; set; }

        public Control Content { get; set; }

        public Thickness OuterMarginThickness { get; set; } = new Thickness(1);
        #endregion

        #region Constructor

        public DialogViewModel(Window window) : base(window)
        {
            TitleHeight = 30;
        }
        #endregion
    }
}
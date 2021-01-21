using System.Windows;
using System.Windows.Controls;

namespace DayHelper
{
    public class ClockDialogViewModel : WindowViewModel
    {
        #region Public Properties

        public string Title { get; set; }

        public Control Content { get; set; }

        public Thickness OuterMarginThickness { get; set; } = new Thickness(1);
        #endregion

        #region Constructor

        public ClockDialogViewModel(Window window) : base(window)
        {
            WindowMinimumWidth = 200;
            WindowMinimumHeight = 100;
            TitleHeight = 30;
        }
        #endregion

        #region Methods

        void startClock()
        {

        }
        void pauseClock()
        {

        }
        #endregion
    }
}
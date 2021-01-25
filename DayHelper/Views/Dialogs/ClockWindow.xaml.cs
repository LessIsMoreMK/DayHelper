using System.Windows;

namespace DayHelper
{
    public partial class ClockWindow : Window
    {
        #region Constructor

        public ClockWindow()
        {
            InitializeComponent();
            DataContext = new ClockDialogViewModel(this);
        }

        #endregion
    }
}

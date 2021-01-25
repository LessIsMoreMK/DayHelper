using System.Windows;

namespace DayHelper
{
    public partial class RemoveListWindow : Window
    {
        #region Constructor

        public RemoveListWindow()
        {
            InitializeComponent();
            DataContext = new RemoveListWindowViewModel(this);
        }

        #endregion
    }
}

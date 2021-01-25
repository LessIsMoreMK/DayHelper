using System.Windows;

namespace DayHelper
{
    public partial class AddListWindow : Window
    {
        #region Constructor

        public AddListWindow()
        {
            InitializeComponent();
            DataContext = new AddListWindowViewModel(this);
        }

        #endregion
    }
}

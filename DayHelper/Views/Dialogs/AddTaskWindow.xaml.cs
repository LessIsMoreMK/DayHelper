using System.Windows;

namespace DayHelper
{
    public partial class AddTaskWindow : Window
    {
        #region Constructor

        public AddTaskWindow()
        {
            InitializeComponent();
            DataContext = new AddTaskWindowViewModel(this);
        }

        #endregion
    }
}

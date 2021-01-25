using DayHelper.DataModel;
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
        public AddTaskWindow(int taskID)
        {
            InitializeComponent();
            DataContext = new AddTaskWindowViewModel(this, taskID);
        }

        #endregion
    }
}

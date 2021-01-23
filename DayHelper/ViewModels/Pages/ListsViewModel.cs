using DayHelper.DataModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DayHelper
{
    public class ListsViewModel : BaseViewModel
    {
        #region Private Members
        private readonly ConnectedRepository repository = new ConnectedRepository();
        #endregion

        #region Public Properties
        public ObservableCollection<string> TaskLists { get; set; }
        #endregion

        #region Commands
        public ICommand GoToTaskCommand { get; set; }
        #endregion

        #region Constructor
        public ListsViewModel()
        {
            List<TaskList> list = repository.GetAllTaskLists();
            TaskLists = new ObservableCollection<string>();
            foreach (TaskList item in list)
            {
                TaskLists.Add(item.Name);
            }

            GoToTaskCommand = new RelayCommand(GoToTask);
        }
        #endregion

        #region Methods
        public void GoToTask()
        {
            IoC.Application.GoToPage(ApplicationPage.Task);
        }
        #endregion
    }
}

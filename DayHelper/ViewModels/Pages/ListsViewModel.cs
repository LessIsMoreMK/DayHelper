using DayHelper.DataModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand TestCommand { get; private set; }
        #endregion

        #region Constructor
        public ListsViewModel()
        {
            List<TaskList> list = repository.GetAllTaskLists();
            TaskLists = new ObservableCollection<string>();
            foreach(TaskList item in list)
            {
                TaskLists.Add(item.Name);
            }


            
            TestCommand = new RelayCommand(CommandMethod);
        }
        #endregion

        #region Methods
        public void CommandMethod()
        {
            
        }
        #endregion
    }
}

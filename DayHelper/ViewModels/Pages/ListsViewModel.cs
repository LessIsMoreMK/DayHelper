using DayHelper.DataModel;
using GalaSoft.MvvmLight.Messaging;
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
        public ICommand CreateListCommand { get; set; }
        public ICommand RemoveListCommand { get; set; }
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
            CreateListCommand = new RelayCommand(CreateList);
            RemoveListCommand = new RelayCommand(RemoveList);
        }
        #endregion

        #region Methods
        public void GoToTask()
        {
            List<TaskList> list = repository.GetAllTaskLists();
            TaskList TL = list.First();
            Messenger.Default.Send<TaskList>(TL);
            IoC.Application.GoToPage(ApplicationPage.Task);
        }
        public void CreateList()
        {
            AddListWindow win2 = new AddListWindow();
            win2.Show();
        }
        public void RemoveList()
        {
            RemoveListWindow win2 = new RemoveListWindow();
            win2.Show();
        }
        #endregion
    }
}

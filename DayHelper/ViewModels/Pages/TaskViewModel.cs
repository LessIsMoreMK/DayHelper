using DayHelper.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Threading.Tasks;
using Task = DayHelper.DataModel.Task;
using System.Threading;

namespace DayHelper
{
    public class TaskViewModel : BaseViewModel
    {
        #region Private Members
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private ObservableCollection<Task> tasks;
        private Task selectedItem;
        #endregion

        #region Public Properties

        public ObservableCollection<Task> Tasks
        {
            get
            {
                if (tasks == null)
                {
                    tasks = new ObservableCollection<Task>();
                }

                return tasks;
            }
            set
            {
                if (value != null)
                {
                    tasks = value;
                }
            }
        }

        
        public Task SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        #endregion

        #region Commands
        public ICommand DeletedCommand { get; set; }
        public ICommand FinishedCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand NotificationCommand { get; set; }
        #endregion

        #region Constructor
        public TaskViewModel()
        {
            List<DayHelper.DataModel.Task> list = repository.GetAllTasks();
            Tasks = new ObservableCollection<Task>(list);


            //Action Buttons
            DeletedCommand = new RelayCommand(Deleted);
            FinishedCommand = new RelayCommand(async () => await FinishedAsync());
            EditCommand = new RelayCommand(Edit);
            NotificationCommand = new RelayCommand(Notification);
        }
        #endregion

        #region Methods

        public async System.Threading.Tasks.Task FinishedAsync()
        {
            await System.Threading.Tasks.Task.Delay(1000);

            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
            //TODO: Move to Finished
        }

        public void Deleted()
        {
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }

            //TODO: Database Move to Deleted
        }

        public void Edit()
        {

        }
        
        public void Notification()
        {

        }
        #endregion
    }


}

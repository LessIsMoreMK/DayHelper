using DayHelper.DataModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DayHelper
{
    public class DeletedViewModel : BaseViewModel
    {
        #region Private Members
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private ObservableCollection<TaskDeleted> tasks;
        private TaskDeleted selectedItem;
        #endregion

        #region Public Properties
        public ObservableCollection<TaskDeleted> Tasks
        {
            get
            {
                if (tasks == null)
                {
                    tasks = new ObservableCollection<TaskDeleted>();
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
        public TaskDeleted SelectedItem
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
        public ICommand DeleteCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        #endregion

        #region Constructor
        public DeletedViewModel()
        {
            List<TaskDeleted> list = repository.GetDeletedTasks();
            Tasks = new ObservableCollection<TaskDeleted>(list);

            DeleteCommand = new RelayCommand(Delete);
            RestoreCommand = new RelayCommand(Restore);
        }
        #endregion

        #region Methods
        public void Delete()
        {
            repository.DeletePermanently(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
        }
        public void Restore()
        {
            repository.MoveToTask(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
        }
        #endregion
    }
}

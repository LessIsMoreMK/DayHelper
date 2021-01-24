using DayHelper.DataModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DayHelper
{
    public class FinishedViewModel : BaseViewModel
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
        public ICommand DeleteCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        #endregion

        #region Constructor
        public FinishedViewModel()
        {
            List<DayHelper.DataModel.Task> list = repository.GetFinishedTasks();
            Tasks = new ObservableCollection<Task>(list);

            DeleteCommand = new RelayCommand(Delete);
            RestoreCommand = new RelayCommand(Restore);
        }
        #endregion

        #region Methods
        public void Delete()
        {
            repository.MoveToDelted(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
        }
        public void Restore()
        {
            repository.MarkAsUnfinished(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
        }
        #endregion
    }
}

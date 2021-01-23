using DayHelper.DataModel;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Task = DayHelper.DataModel.Task;

namespace DayHelper
{
    public class TaskViewModel : BaseViewModel
    {
        #region Private Members
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private CollectionViewSource CVS { get; set; }

        private ObservableCollection<Task> tasks;
        private Task selectedItem;

        private ObservableCollection<Difficulty> difficulty;
        private Difficulty selectedDifficulty;
        private bool canCanRemoveDifficultyFilter;

        
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

        public Difficulty SelectedDifficulty
        {
            get { return selectedDifficulty; }
            set
            {
                if (selectedDifficulty == value)
                    return;
                selectedDifficulty = value;
                OnPropertyChanged("SelectedDifficulty");
                ApplyFilter(FilterField.Difficulty);
            }
        }
        public bool CanRemoveDifficultyFilter
        {
            get { return canCanRemoveDifficultyFilter; }
            set
            {
                canCanRemoveDifficultyFilter = value;
                OnPropertyChanged("CanRemoveDifficultyFilter");
            }
        }

        
        #endregion

        #region Commands
        public ICommand DeletedCommand { get; set; }
        public ICommand FinishedCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand NotificationCommand { get; set; }

        public ICommand RemoveDifficultyFilterCommand { get; set; }
        #endregion

        #region Constructor
        public TaskViewModel()
        {
            LoadData();
            
            Messenger.Default.Register<ViewCollectionViewSourceMessageToken>(this, Handle_ViewCollectionViewSourceMessageToken);


            //Action Buttons
            DeletedCommand = new RelayCommand(Deleted);
            FinishedCommand = new RelayCommand(async () => await Finished());
            EditCommand = new RelayCommand(Edit);
            NotificationCommand = new RelayCommand(Notification);

            //Filter Buttons
            RemoveDifficultyFilterCommand = new RelayCommand(RemoveYearFilter, () => CanRemoveDifficultyFilter);
        }
        #endregion

        #region Methods
        public void LoadData()
        {
            List<DayHelper.DataModel.Task> list = repository.GetAllTasks();
            Tasks = new ObservableCollection<Task>(list);


            var things = repository.GetAllTasks();
            var q1 = from t in list
                     select t.Difficulty;
            difficulty = new ObservableCollection<Difficulty>(q1.Distinct());
        }

        private void Handle_ViewCollectionViewSourceMessageToken(ViewCollectionViewSourceMessageToken token)
        {
            CVS = token.CVS;
        }

        public async System.Threading.Tasks.Task Finished()
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

        #region Filtering Methods
        private enum FilterField
        {
            Difficulty,
            None
        }
        private void ApplyFilter(FilterField field)
        {
            switch (field)
            {
                case FilterField.Difficulty:
                    AddDifficultyFilter();
                    break;
                default:
                    break;
            }
        }


        private void FilterByDifficulty(object sender, FilterEventArgs e)
        {
            var src = e.Item as Task;
            if (src == null)
                e.Accepted = false;
            else if (SelectedDifficulty != src.Difficulty)
                e.Accepted = false;
        }
        public void AddDifficultyFilter()
        {
            if (canCanRemoveDifficultyFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByDifficulty);
                CVS.Filter += new FilterEventHandler(FilterByDifficulty);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByDifficulty);
                CanRemoveDifficultyFilter = true;
            }
        }
        public void RemoveYearFilter()
        {
            CVS.Filter -= new FilterEventHandler(FilterByDifficulty);
            SelectedDifficulty = DataModel.Difficulty.NotDefined; //TODO: nothing
            CanRemoveDifficultyFilter = false;
        }
        #endregion
    }


}

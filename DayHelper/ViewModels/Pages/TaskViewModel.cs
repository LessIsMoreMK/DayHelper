using DayHelper.DataModel;
using GalaSoft.MvvmLight.Messaging;
using System;
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
        private TaskList TL { get; set; }

        private ObservableCollection<Task> tasks;
        private Task selectedItem;
        private string selectedText;

        private ObservableCollection<Difficulty> difficulty;
        private Difficulty selectedDifficulty;
        private bool canCanRemoveDifficultyFilter;

        private ObservableCollection<Priority> priority;
        private Priority selectedPriority;
        private bool canCanRemovePriorityFilter;

        private ObservableCollection<DateTime> startDate;
        private DateTime selectedStartDate;
        private bool canCanRemoveStartDateFilter;

        private ObservableCollection<DateTime> endDate;
        private DateTime selectedEndDate;
        private bool canCanRemoveEndDateFilter;
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
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                selectedText = value;
                CVS.Filter += new FilterEventHandler(FilterByText);
                OnPropertyChanged("SelectedText");
            }
        }
        private void FilterByText(object sender, FilterEventArgs e)
        {
            var src = e.Item as Task;
            if (src == null)
                e.Accepted = false;
            else if (!src.Content.ToLower().Contains(SelectedText.ToLower()))
                e.Accepted = false;
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

        public Priority SelectedPriority
        {
            get { return selectedPriority; }
            set
            {
                if (selectedPriority == value)
                    return;
                selectedPriority = value;
                OnPropertyChanged("SelectedPriority");
                ApplyFilter(FilterField.Priority);
            }
        }
        public bool CanRemovePriorityFilter
        {
            get { return canCanRemovePriorityFilter; }
            set
            {
                canCanRemovePriorityFilter = value;
                OnPropertyChanged("CanRemovePriorityFilter");
            }
        }

        public DateTime SelectedStartDate
        {
            get { return selectedStartDate; }
            set
            {
                if (selectedStartDate == value)
                    return;
                selectedStartDate = value;
                OnPropertyChanged("SelectedStartDate");
                ApplyFilter(FilterField.StartDate);
            }
        }
        public bool CanRemoveStartDateFilter
        {
            get { return canCanRemoveStartDateFilter; }
            set
            {
                canCanRemoveStartDateFilter = value;
                OnPropertyChanged("CanRemoveStartDateFilter");
            }
        }

        public DateTime SelectedEndDate
        {
            get { return selectedEndDate; }
            set
            {
                if (selectedEndDate == value)
                    return;
                selectedEndDate = value;
                OnPropertyChanged("SelectedEndDate");
                ApplyFilter(FilterField.EndDate);
            }
        }
        public bool CanRemoveEndDateFilter
        {
            get { return canCanRemoveEndDateFilter; }
            set
            {
                canCanRemoveEndDateFilter = value;
                OnPropertyChanged("CanRemoveEndDateFilter");
            }
        }
        #endregion

        #region Commands
        public ICommand DeletedCommand { get; set; }
        public ICommand FinishedCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand NotificationCommand { get; set; }

        public ICommand RemoveDifficultyFilterCommand { get; set; }
        public ICommand RemovePriorityFilterCommand { get; set; }
        public ICommand RemoveStartDateFilterCommand { get; set; }
        public ICommand RemoveEndDateFilterCommand { get; set; }
        public ICommand ResetFiltersCommand { get; set; }
        #endregion

        #region Constructor
        public TaskViewModel()
        {
            LoadData();
            
            Messenger.Default.Register<ViewCollectionViewSourceMessageToken>(this, Handle_ViewCollectionViewSourceMessageToken);
            Messenger.Default.Unregister<TaskListMessageToken>(this, Handle_TaskListSourceMessageToken);

            //Action Buttons
            DeletedCommand = new RelayCommand(Deleted);
            FinishedCommand = new RelayCommand(async () => await Finished());
            EditCommand = new RelayCommand(Edit);
            NotificationCommand = new RelayCommand(Notification);

            //Filter Buttons
            RemoveDifficultyFilterCommand = new RelayCommand(RemoveDifficultyFilter, () => CanRemoveDifficultyFilter);
            RemovePriorityFilterCommand = new RelayCommand(RemovePriorityFilter, () => CanRemovePriorityFilter);
            RemoveStartDateFilterCommand = new RelayCommand(RemoveStartDateFilter, () => CanRemoveStartDateFilter);
            RemoveEndDateFilterCommand = new RelayCommand(RemoveEndDateFilter, () => CanRemoveEndDateFilter);

            ResetFiltersCommand = new RelayCommand(ResetFilters, null);
        }

        #endregion

        #region Methods
        public void LoadData()
        {
            List<DayHelper.DataModel.Task> list = repository.GetAllTasks();
            Tasks = new ObservableCollection<Task>(list);

            selectedStartDate = System.DateTime.Today;
            selectedEndDate = System.DateTime.Today;

            var q1 = from t in list
                     select t.Difficulty;
            difficulty = new ObservableCollection<Difficulty>(q1.Distinct());

            var q2 = from t in list
                     select t.Priority;
            priority = new ObservableCollection<Priority>(q2.Distinct());

            var q3 = from t in list
                     select t.DateCreated;
            startDate = new ObservableCollection<DateTime>(q3.Distinct());

            var q4 = from t in list
                     select t.DateToFinish;
            endDate = new ObservableCollection<DateTime>(q4.Distinct());
        }

        private void Handle_ViewCollectionViewSourceMessageToken(ViewCollectionViewSourceMessageToken token)
        {
            CVS = token.CVS;
        }

        private void Handle_TaskListSourceMessageToken(TaskListMessageToken token)
        {
            TL = token.TL;
        }

        public async System.Threading.Tasks.Task Finished()
        {
            await System.Threading.Tasks.Task.Delay(1000);
            repository.MarkAsFinished(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
            
        }
        public void Deleted()
        {
            repository.MoveToDelted(SelectedItem);
            if (null != SelectedItem)
            {
                tasks.Remove(SelectedItem);
            }
            
        }
        public void Edit()
        {

        }
        public void Notification()
        {

        }
        #endregion

        #region Filtering Methods
        public void ResetFilters()
        {
            RemoveDifficultyFilter();
            RemovePriorityFilter();
            RemoveStartDateFilter();
            RemoveEndDateFilter();
            SelectedText = "";
        }
        private enum FilterField
        {
            Difficulty,
            Priority,
            StartDate,
            EndDate,
            None
        }
        private void ApplyFilter(FilterField field)
        {
            switch (field)
            {
                case FilterField.Difficulty:
                    AddDifficultyFilter();
                    break;
                case FilterField.Priority:
                    AddPriorityFilter();
                    break;
                case FilterField.StartDate:
                    AddStartDateFilter();
                    break;
                case FilterField.EndDate:
                    AddEndDateFilter();
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
        public void RemoveDifficultyFilter()
        {
            CVS.Filter -= new FilterEventHandler(FilterByDifficulty);
            CanRemoveDifficultyFilter = false;
        }

        private void FilterByPriority(object sender, FilterEventArgs e)
        {
            var src = e.Item as Task;
            if (src == null)
                e.Accepted = false;
            else if (SelectedPriority != src.Priority)
                e.Accepted = false;
        }
        public void AddPriorityFilter()
        {
            if (canCanRemoveDifficultyFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByPriority);
                CVS.Filter += new FilterEventHandler(FilterByPriority);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByPriority);
                CanRemoveDifficultyFilter = true;
            }
        }
        public void RemovePriorityFilter()
        {
            CVS.Filter -= new FilterEventHandler(FilterByPriority);
            CanRemovePriorityFilter = false;
        }

        private void FilterByStartDate(object sender, FilterEventArgs e)
        {
            var src = e.Item as Task;
            if (src == null)
                e.Accepted = false;
            else if (SelectedStartDate >= src.DateCreated)
                e.Accepted = false;
        }
        public void AddStartDateFilter()
        {
            if (canCanRemoveStartDateFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByStartDate);
                CVS.Filter += new FilterEventHandler(FilterByStartDate);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByStartDate);
                CanRemoveStartDateFilter = true;
            }
        }
        public void RemoveStartDateFilter()
        {
            CVS.Filter -= new FilterEventHandler(FilterByStartDate);
            CanRemoveStartDateFilter = false;
        }

        private void FilterByEndDate(object sender, FilterEventArgs e)
        {
            var src = e.Item as Task;
            if (src == null)
                e.Accepted = false;
            else if (SelectedEndDate <= src.DateToFinish) //TODO: Check validity
                e.Accepted = false;
        }
        public void AddEndDateFilter()
        {
            if (canCanRemoveEndDateFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByEndDate);
                CVS.Filter += new FilterEventHandler(FilterByEndDate);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByEndDate);
                CanRemoveEndDateFilter = true;
            }
        }
        public void RemoveEndDateFilter()
        {
            CVS.Filter -= new FilterEventHandler(FilterByEndDate);
            CanRemoveEndDateFilter = false;
        }
        #endregion
    }
}

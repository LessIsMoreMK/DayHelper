using DayHelper.DataModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DayHelper
{
    public class AddTaskWindowViewModel : WindowViewModel
    {
        #region Private Fields
        private readonly ConnectedRepository repository = new ConnectedRepository();
        private Window thisWindow;
        private string selectedText;
        private TaskList selectedTaskList;
        private Difficulty selectedDifficulty;
        private Priority selectedPriority;
        private DateTime selectedEndDate;
        private List<TaskList> taskList;
        private List<string> taskListName;
        private int taskID;
        #endregion

        #region Public Properties
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                selectedText = value;
                OnPropertyChanged("SelectedText");
            }
        }
        public List<string> TaskListName
        {
            get { return taskListName; }
            set
            {
                taskListName = value;
                OnPropertyChanged("TaskListName");
            }
        }
        public List<TaskList> TaskList
        {
            get { return taskList; }
            set
            {
                taskList = value;
                OnPropertyChanged("TaskList");
            }
        }
        public TaskList SelectedTaskList
        {
            get { return selectedTaskList; }
            set
            {
                if (selectedTaskList == value)
                    return;
                selectedTaskList = value;
                OnPropertyChanged("SelectedTaskList");
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
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; set; }
        #endregion

        #region Constructor

        public AddTaskWindowViewModel(Window window) : base(window)
        {
            SaveCommand = new RelayCommand(Save);

            thisWindow = window;

            selectedEndDate = System.DateTime.Today.AddDays(1);

            taskList = repository.GetAllTaskLists();
            TaskListName = new List<string>();
            foreach (TaskList t in taskList)
                taskListName.Add(t.Name);
        }
        public AddTaskWindowViewModel(Window window, int taskID) : base(window)
        {
            SaveCommand = new RelayCommand(Save);

            this.taskID = taskID;
            thisWindow = window;

            selectedEndDate = System.DateTime.Today.AddDays(1);

            taskList = repository.GetAllTaskLists();
            TaskListName = new List<string>();
            foreach (TaskList t in taskList)
                taskListName.Add(t.Name);

            SelectedTaskList = null;
            Task task = repository.GetTask(taskID);
            selectedPriority = task.Priority;
            selectedDifficulty = task.Difficulty;
            selectedEndDate = task.DateToFinish;
            selectedText = task.Content;
            selectedTaskList = task.TaskList;

        }
        #endregion

        #region Methods
        public void Save()
        {
            Task task;
            if (taskID != 0)
            {
                task = repository.GetTask(taskID);
            }
            else
                task = new Task();

            task.Finished = false;
            task.Content = selectedText;
            task.Difficulty = selectedDifficulty; 
            task.Priority = SelectedPriority;
            task.DateCreated = DateTime.Now;
            task.DateToFinish = SelectedEndDate;

            foreach (TaskList t in taskList)
            {
                if(SelectedTaskList==t)
                {
                    task.TaskList = t;
                    break;
                }
            }
            
            repository.AddTask(task);
            thisWindow.Close();
        }
        #endregion
    }
}
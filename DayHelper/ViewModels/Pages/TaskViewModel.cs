using DayHelper.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DayHelper
{
    public class TaskViewModel : BaseViewModel
    {
        private readonly ConnectedRepository repository = new ConnectedRepository();


        #region Public Properties
        private ObservableCollection<Task> tasks;

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
        #endregion

        #region Commands

        #endregion

        #region Constructor
        public TaskViewModel()
        {
            List<DayHelper.DataModel.Task> list = repository.GetAllTasks();
            Tasks = new ObservableCollection<Task>(list);
        }
        #endregion

        #region Methods

        #endregion
    }


}


using System;
using System.Collections.Generic;
using System.Linq;

namespace DayHelper.DataModel
{
    public class ConnectedRepository
    {
        private readonly DayHelperContext context = new DayHelperContext();

        #region Display Methods
        public List<Task> GetAllTasks()
        {
            return context.Tasks.Where(t => t.Finished == false).ToList();
        }
        public List<Task> GetFinishedTasks()
        {
            return context.Tasks.Where(t => t.Finished == true).ToList();
        }
        public List<TaskDeleted> GetDeletedTasks()
        {
            return context.TaskDeleted.ToList();
        }
        public List<TaskList> GetAllTaskLists()
        {
            return context.TaskLists.ToList();
        }
        #endregion

        #region Commands Methods
        public void DeleteTask(TaskDeleted deleted)
        {
            context.TaskDeleted.Remove(deleted);
            context.SaveChanges();
        }
        public void MoveToDelted(Task task)
        {
            TaskDeleted deleted = new TaskDeleted
            {
                Content = task.Content,
                Finished = task.Finished,
                Priority = task.Priority,
                Difficulty = task.Difficulty,
                DateCreated = task.DateCreated,
                DateToFinish = DateTime.Now,
                TaskList = task.TaskList,
            };
            
            context.TaskDeleted.Add(deleted);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
        public void MarkAsFinished(Task task)
        {
            task.Finished = true;
            task.DateToFinish = DateTime.Now;
            context.SaveChanges();
        }
        public void MarkAsUnfinished(Task task)
        {
            task.Finished = false;
            context.SaveChanges();
        }
        public void DeletePermanently(TaskDeleted deleted)
        {
            context.TaskDeleted.Remove(deleted);
            context.SaveChanges();
        }
        public void MoveToTask(TaskDeleted deleted)
        {
            Task task = new Task
            {
                Content = deleted.Content,
                Finished = deleted.Finished,
                Priority = deleted.Priority,
                Difficulty = deleted.Difficulty,
                DateCreated = deleted.DateCreated,
                DateToFinish = deleted.DateToFinish,
                TaskList = deleted.TaskList,
            };

            context.TaskDeleted.Remove(deleted);
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        public void AddList(string name)
        {
            var tasklist = new TaskList
            {
                Name = name,
            };
            context.TaskLists.Add(tasklist);
            context.SaveChanges();
        }
        public void RemoveList(string name)
        {
            TaskList tasklist = context.TaskLists.Where(t => t.Name == name).First();
            if(tasklist!=null)
            {
                context.TaskLists.Remove(tasklist);
                context.SaveChanges();
            }
        }
        #endregion

        #region Analyze Methods
        public int AmountOfActiveTasks()
        {
            return context.Tasks.Where(t => t.Finished == false).ToList().Count();
        }
        public int AmountOfFinishedTasks()
        {
            return context.Tasks.Where(t => t.Finished == true).ToList().Count();
        }
        public int AmountOfFinishedHardTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Difficulty == Difficulty.Trudne)).ToList().Count();
        }
        public int AmountOfFinishedMediumTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Difficulty == Difficulty.Średnie)).ToList().Count();
        }
        public int AmountOfFinishedEasyTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Difficulty == Difficulty.Łatwe)).ToList().Count();
        }
        public int AmountOfFinishedUndefinedTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Difficulty == Difficulty.Niezdefiniowana)).ToList().Count();
        }

        public int AmountOfFinishedNormalTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Normalne)).ToList().Count();
        }
        public int AmountOfFinishedImportantTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Ważne)).ToList().Count();
        }
        public int AmountOfFinishedCriticalTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Krytyczne)).ToList().Count();
        }
        public int AmountOfFinishedUndefinedPriorityTasks()
        {
            return context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Niezdefiniowany)).ToList().Count();
        }

        public int AmountOfDaysNeededForFinishingNormalTasks()
        {
            List<Task> list = context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Normalne)).ToList();

            double sum = 0, amount = 0;
            foreach(Task l in list)
            {
                sum +=  (l.DateToFinish - l.DateCreated).TotalDays;
                amount += 1;
            }
            return (int)(sum/amount);
        }
        public int AmountOfDaysNeededForFinishingImportantTasks()
        {
            List<Task> list = context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Ważne)).ToList();

            double sum = 0, amount = 0;
            foreach (Task l in list)
            {
                sum += (l.DateToFinish - l.DateCreated).TotalDays;
                amount += 1;
            }
            return (int)(sum / amount);
        }
        public int AmountOfDaysNeededForFinishingCriticalTasks()
        {
            List<Task> list = context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Krytyczne)).ToList();

            double sum = 0, amount = 0;
            foreach (Task l in list)
            {
                sum += (l.DateToFinish - l.DateCreated).TotalDays;
                amount += 1;
            }
            return (int)(sum / amount);
        }
        public int AmountOfDaysNeededForFinishingUndefinedTasks()
        {
            List<Task> list = context.Tasks.Where(t => (t.Finished == true) && (t.Priority == Priority.Niezdefiniowany)).ToList();

            double sum = 0, amount = 0;
            foreach (Task l in list)
            {
                sum += (l.DateToFinish - l.DateCreated).TotalDays;
                amount += 1;
            }
            return (int)(sum / amount);
        }
        #endregion

    }
}

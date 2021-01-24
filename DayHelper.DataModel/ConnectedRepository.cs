
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayHelper.DataModel
{
    public class ConnectedRepository
    {
        private readonly DayHelperContext context = new DayHelperContext();

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
    }
}

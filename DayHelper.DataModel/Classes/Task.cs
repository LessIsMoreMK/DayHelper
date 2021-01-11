using System;
using System.Collections.Generic;

namespace DayHelper.DataModel
{
    public class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Finished { get; set; }
        public Priority Priority { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateToFinish { get; set; }
        public TaskList TaskList { get; set; }
        public List<Tag> Tags { get; set; }
    }
}

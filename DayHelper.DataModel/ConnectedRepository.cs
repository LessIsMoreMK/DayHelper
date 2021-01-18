
using System.Collections.Generic;
using System.Linq;

namespace DayHelper.DataModel
{
    public class ConnectedRepository
    {
        private readonly DayHelperContext context = new DayHelperContext();

        public List<Task> GetAllTasks()
        {
            return context.Tasks.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jTask.Models
{

    
    public class TaskRepository
    {
        private static List<Task> tasks;

        public TaskRepository()
        {
            if (tasks == null)
            {
                tasks = new List<Task>();
                tasks.Add(new Task() {Id = 1, IsDone = false, Name = "Cook Dinner"});
                tasks.Add(new Task() {Id = 2, IsDone = false, Name = "Take out the trash"});
            }
        }
    

        public List<Task> FindAll()
        {
            return tasks;
        }

        public void Add(Task task)
        {
            task.Id = tasks.Max(x => x.Id) + 1;
            tasks.Add(task);
        }

        public void Remove(int id)
        {
            tasks.RemoveAll(x => x.Id == id);
        }

        public Task Find(int id)
        {
            return tasks.Single(x => x.Id == id);
        }

        public void Complete(int id)
        {
            Find(id).IsDone = true;
        }
    }
}

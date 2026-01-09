using TaskManagementAPI.Models;
using System.Collections.Generic;

namespace TaskManagementAPI.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem GetById(int id);
        void Add(TaskItem task);
        void Update(TaskItem task);
    }
}

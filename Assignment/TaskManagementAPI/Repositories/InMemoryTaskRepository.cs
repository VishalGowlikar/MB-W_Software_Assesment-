using TaskManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementAPI.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();

        public IEnumerable<TaskItem> GetAll() => _tasks;

        // public TaskItem GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
        public TaskItem GetById(int id) =>
    _tasks.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Task not found");



        public void Add(TaskItem task)
        {
            _tasks.Add(task);
        }

        public void Update(TaskItem task)
        {
            var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existing != null)
            {
                _tasks.Remove(existing);
                _tasks.Add(task);
            }
        }
    }
}

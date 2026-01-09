using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        public IEnumerable<TaskItem> GetAllTasks() => _repository.GetAll();

        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void AddTask(TaskItem task)
        {
            ValidateTask(task);
            _repository.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            ValidateTask(task);
            _repository.Update(task);
        }

        private void ValidateTask(TaskItem task)
        {
            if (task.DueDate < DateTime.Today)
                throw new Exception("Due date cannot be in the past.");

            if (task.DueDate.DayOfWeek == DayOfWeek.Saturday || task.DueDate.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception("Due date cannot be on a weekend.");

            if (task.Priority == Priority.High)
            {
                int highPriorityCount = _repository.GetAll()
                    .Count(t => t.DueDate.Date == task.DueDate.Date && t.Priority == Priority.High && t.Status != Status.Finished);

                if (highPriorityCount >= 100)
                    throw new Exception("Cannot have more than 100 high priority tasks for the same due date.");
            }
        }
    }
}


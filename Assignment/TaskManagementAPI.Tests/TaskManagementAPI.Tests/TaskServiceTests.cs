using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Services;
using Xunit;
using System;

namespace TaskManagementAPI.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService _service;

        public TaskServiceTests()
        {
            var repo = new InMemoryTaskRepository();
            _service = new TaskService(repo);
        }

        [Fact]
        public void AddTask_PastDueDate_ShouldThrowException()
        {
            var task = new TaskItem
            {
                Id = 1,
                Name = "Test Task",
                Description = "Test Description",
                StartDate = DateTime.Today,
                DueDate = DateTime.Today.AddDays(-1),
                Priority = Priority.Low,
                Status = Status.New
            };

            Assert.Throws<Exception>(() => _service.AddTask(task));
        }
    }
}

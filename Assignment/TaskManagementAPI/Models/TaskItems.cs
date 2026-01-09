using System;

namespace TaskManagementAPI.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        New,
        InProgress,
        Finished
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}

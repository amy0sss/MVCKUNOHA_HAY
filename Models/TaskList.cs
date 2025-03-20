using System;
using System.ComponentModel.DataAnnotations;

namespace MVCKUNOHA_HAY.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } = "Pending";
        public DateTime DateAssigned { get; set; }
        public DateTime DateDeadline { get; set; }
        public string? AssignedBy { get; set; }
    }
}
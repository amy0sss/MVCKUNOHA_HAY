using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("AssignedTo")]
        public User? AssignedTo { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        [RegularExpression("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
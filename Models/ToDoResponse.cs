using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    public class ToDoResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        [Required]
        public bool Completed { get; set; }

        [Required] //making the FK relationship
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}

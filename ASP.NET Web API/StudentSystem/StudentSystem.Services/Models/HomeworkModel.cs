namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HomeworkModel
    {
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime Deadline { get; set; }
    }
}
namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public DateTime? TimeSent { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}

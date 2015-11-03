namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
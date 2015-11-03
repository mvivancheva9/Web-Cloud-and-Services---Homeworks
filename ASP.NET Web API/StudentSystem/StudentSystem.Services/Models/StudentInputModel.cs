namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentInputModel
    {
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        public string Number { get; set; }

        public string Email { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [Range(18, 120)]
        public byte Age { get; set; }
    }
}
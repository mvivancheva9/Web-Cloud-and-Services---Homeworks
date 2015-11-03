namespace ArtistsSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AlbumRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(1850, 2050)]
        public int Year { get; set; }

        public string Producer { get; set; }
    }
}
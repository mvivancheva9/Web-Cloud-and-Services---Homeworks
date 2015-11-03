namespace ArtistsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Range(30, 1800)]
        public double DurationInSeconds { get; set; }

        public MusicGanre Genre { get; set; }

        public int? ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}

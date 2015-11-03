namespace ArtistsSystem.Services.Models
{
    public class SongResponseModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public double DurationInSeconds { get; set; }

        public string Genre { get; set; }
    }
}
namespace ArtistsSystem.Services.Models
{
    using System.Collections.Generic;

    public class AlbumResponseModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public virtual IEnumerable<SongResponseModel> Songs { get; set; }
    }
}
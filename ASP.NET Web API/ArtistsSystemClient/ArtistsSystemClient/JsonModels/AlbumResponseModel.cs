namespace ArtistsSystemClient.JsonModels
{
    using System.Collections.Generic;

    public class AlbumResponseModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public IEnumerable<SongResponseModel> Songs { get; set; }
    }
}
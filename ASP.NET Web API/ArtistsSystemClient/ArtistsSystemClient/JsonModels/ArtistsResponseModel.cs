namespace ArtistsSystemClient.JsonModels
{
    using System;
    using System.Collections.Generic;

    public class ArtistsResponseModel
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<AlbumResponseModel> Albums { get; set; }
    }
}
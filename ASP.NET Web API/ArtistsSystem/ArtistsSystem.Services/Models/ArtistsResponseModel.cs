namespace ArtistsSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArtistsSystem.Models;
    using System.Linq.Expressions;

    public class ArtistsResponseModel
    {
        public static Expression<Func<Artist, ArtistsResponseModel>> FromArtist
        {
            get
            {
                return a => new ArtistsResponseModel
                {
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(al => new AlbumResponseModel
                    {
                        Title = al.Title,
                        Producer = al.Producer,
                        Year = al.Year,
                        Songs = al.Songs.Select(s => new SongResponseModel
                        {
                            Title = s.Title,
                            DurationInSeconds = s.DurationInSeconds,
                            Genre = s.Genre.ToString(),
                            Year = s.Year
                        })
                    })
                };
            }
        }

        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<AlbumResponseModel> Albums { get; set; }
    }
}
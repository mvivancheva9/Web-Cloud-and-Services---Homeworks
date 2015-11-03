namespace ArtistsSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using Models;

    public class AlbumsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums
                .All()
                .Select(a => new AlbumResponseModel
                {
                    Title = a.Title,
                    Producer = a.Producer,
                    Year = a.Year,
                    Songs = a.Songs.Select(s => new SongResponseModel
                    {
                        Title = s.Title,
                        DurationInSeconds = s.DurationInSeconds,
                        Year = s.Year,
                        Genre = s.Genre.ToString()
                    })
                }).ToList();

            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumRequestModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newAlbum = new Album
            {
                Title = album.Title,
                Year = album.Year,
                Producer = album.Producer
            };

            this.data.Albums.Add(newAlbum);
            this.data.Albums.SaveChanges();

            return Ok(new { Album = album, Id = newAlbum.Id });
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int artistId, SongResponseModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var artist = this.data.Artists
                .All()
                .FirstOrDefault(a => a.Id == artistId);

            if (artist == null)
            {
                return BadRequest("Artist not exist - invalid id");
            }

            var album = this.data.Albums
                .All()
                .FirstOrDefault(a => a.Id == id && a.Artists.FirstOrDefault(ar => ar.Id == artistId) != null);

            if (album == null)
            {
                return BadRequest("Album not exist - invalid id");
            }

            var songToAdd = new Song
            {
                Title = song.Title,
                Year = song.Year,
                DurationInSeconds = song.DurationInSeconds,
                Genre = (MusicGanre)Enum.Parse(typeof(MusicGanre), song.Genre),
                ArtistId = artistId
            };

            album.Songs.Add(songToAdd);
            this.data.Albums.SaveChanges();

            return Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.data.Albums
                            .All()
                            .FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return BadRequest("Album not exist - invalid id");
            }

            this.data.Albums.Delete(album);
            this.data.Albums.SaveChanges();

            return Ok();
        }
    }
}

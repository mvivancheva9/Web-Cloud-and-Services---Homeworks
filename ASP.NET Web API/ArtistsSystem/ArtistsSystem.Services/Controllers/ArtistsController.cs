namespace ArtistsSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using ArtistsSystem.Services.Models;
    using System;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class ArtistsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var allArtists = this.data.Artists
                .All()
                .Select(ArtistsResponseModel.FromArtist);

            return  Ok(allArtists);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var artists = this.data.Artists
                .All()
                .Where(a => a.Id == id)
                .Select(ArtistsResponseModel.FromArtist)
                .FirstOrDefault();

            if(artists == null)
            {
                return BadRequest("Artist not exist - invalid id");
            }

            return Ok(artists);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistRequestModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var country = this.data
                .Countries
                .All()
                .FirstOrDefault(c => c.Name.ToLower() == artist.Country.ToLower());

            if(country == null)
            {
                country = new Country
                {
                    Name = artist.Country
                };

                this.data.Countries.Add(country);
                this.data.Countries.SaveChanges();
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                DateOfBirth = artist.DateOfBirth
            };

            newArtist.CountryId = country.Id;

            this.data.Artists.Add(newArtist);
            this.data.Artists.SaveChanges();

            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistRequestModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var country = this.data
                .Countries
                .All()
                .FirstOrDefault(c => c.Name.ToLower() == artist.Country.ToLower());

            if (country == null)
            {
                country = new Country
                {
                    Name = artist.Country
                };

                this.data.Countries.Add(country);
                this.data.Countries.SaveChanges();
            }

            var artistFromDatabase = this.data.Artists.All()
                .FirstOrDefault(a => a.Id == id);

            if(artistFromDatabase == null)
            {
                return BadRequest("Artist not exist - invalid id");
            }

            artistFromDatabase.Name = artist.Name;
            artistFromDatabase.DateOfBirth = artist.DateOfBirth;
            artistFromDatabase.CountryId = country.Id;

            this.data.Artists.SaveChanges();

            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artistFromDatabase = this.data.Artists.All()
                .FirstOrDefault(a => a.Id == id);

            if (artistFromDatabase == null)
            {
                return BadRequest("Artist not exist - invalid id");
            }

            this.data.Artists.Delete(artistFromDatabase);
            this.data.Artists.SaveChanges();

            return Ok();
        }
    }
}

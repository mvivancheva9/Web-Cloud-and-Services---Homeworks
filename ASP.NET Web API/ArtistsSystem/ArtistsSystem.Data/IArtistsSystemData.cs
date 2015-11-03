namespace ArtistsSystem.Data
{
    using ArtistsSystem.Data.Repositories;
    using ArtistsSystem.Models;

    public interface IArtistsSystemData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        IRepository<Country> Countries { get; }

        void SaveChanges();
    }
}

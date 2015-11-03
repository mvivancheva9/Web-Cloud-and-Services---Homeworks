namespace ArtistsSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ArtistsSystem.Models;

    public interface IArtistsDbContext
    {
        IDbSet<Artist> Atists { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<Country> Countries { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

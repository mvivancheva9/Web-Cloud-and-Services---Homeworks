namespace ArtistsSystem.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class ArtistsDbContext : DbContext, IArtistsDbContext
    {
        public ArtistsDbContext()
            : base("ArtistsSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());
        }

        public virtual IDbSet<Artist> Atists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}

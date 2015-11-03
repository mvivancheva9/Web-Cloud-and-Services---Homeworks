namespace ArtistsSystem.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IQueryable<T> All();

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}

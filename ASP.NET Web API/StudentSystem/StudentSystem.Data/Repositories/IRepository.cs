namespace StudentSystem.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T Entity);

        IQueryable<T> All();

        void Update(T Entity);

        void Delete(T Entity);

        void Detach(T Entity);

        void SaveChanges();
    }
}

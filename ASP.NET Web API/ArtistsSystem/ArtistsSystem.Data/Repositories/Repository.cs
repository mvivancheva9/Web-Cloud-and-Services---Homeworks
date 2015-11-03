using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistsSystem.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IArtistsDbContext context;
        private IDbSet<T> set;

        public Repository()
            :this(new ArtistsDbContext())
        {
        }

        public Repository(IArtistsDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public void Add(T entity)
        {
            ChangeEntityState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Delete(T entity)
        {
            ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            ChangeEntityState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            ChangeEntityState(entity, EntityState.Modified);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}

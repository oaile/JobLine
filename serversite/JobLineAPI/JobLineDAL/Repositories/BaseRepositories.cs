using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JobLineDAL.Contracts;
using JobLineDAL.Entities;

namespace JobLineDAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext context;

        public BaseRepository(IDbContext context)
        {
            this.context = context;
        }

        private IDbSet<TEntity> GetEntities()
        {
            return this.context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return GetEntities().AsQueryable().SingleOrDefault(x => x.Id == id);
        }
        public void Update(TEntity entity)
        {
            var original = GetById(entity.Id);

            if (original != null)
            {
                context.Entry(original).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            var original = GetById(entity.Id);
            if (original != null)
            {
                GetEntities().Remove(original);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntities().AsQueryable();
        }
        public IQueryable<TEntity> Search<TOrderBy>(Expression<Func<TEntity, bool>> criteria,
                    Expression<Func<TEntity, TOrderBy>> orderBy,
                    int pageIndex, int pageSize, out int total, SortOrder sortOrder = SortOrder.Ascending)
        {
            total = GetEntities().AsQueryable().Count();//reference

            if (sortOrder == SortOrder.Ascending)
            {
                return GetEntities().AsQueryable()
                        .Where(criteria)
                        .OrderBy(orderBy)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
            }
            return GetEntities().AsQueryable().Where(criteria).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            return GetEntities().Add(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

    }
}

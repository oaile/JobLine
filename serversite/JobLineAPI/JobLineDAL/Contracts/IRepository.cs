﻿using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace JobLineDAL.Contracts
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Search<TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex, int pageSize, out int total, SortOrder sortOrder = SortOrder.Ascending);

        TEntity GetById(Guid id);

        TEntity Insert(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
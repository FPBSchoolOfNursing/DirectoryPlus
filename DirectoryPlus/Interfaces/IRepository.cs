﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace DirectoryPlus.Interfaces
{
    public interface IRepository<T>
    {
        bool Insert(T entity);
        bool Delete(T entity);
        bool Delete(int entityid);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        bool InsertOrUpdate(T entity);
    }
}

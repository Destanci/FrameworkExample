using FrameworkExample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
    }
}

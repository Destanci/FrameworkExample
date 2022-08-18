using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        Category GetWithAllRelated(Expression<Func<Category, bool>> filter);
        List<Category> GetListWithAllRelated(Expression<Func<Category, bool>> filter);
    }
}

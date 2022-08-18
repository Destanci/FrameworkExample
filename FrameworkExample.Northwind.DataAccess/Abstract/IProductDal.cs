using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Product GetWithAllRelated(Expression<Func<Product, bool>> filter);
        List<Product> GetListWithAllRelated(Expression<Func<Product, bool>> filter);
    }
}

using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IProductService
    {
        StatusData<Product> GetRelated(Expression<Func<Product, bool>> filter);
        StatusData<IList<Product>> GetListRelated(Expression<Func<Product, bool>> filter = null);
        StatusData<Product> Get(Expression<Func<Product, bool>> filter);
        StatusData<IList<Product>> GetList(Expression<Func<Product, bool>> filter = null);
        StatusData<Product> Add(Product entity);
        StatusData<Product> Update(Product entity);
        StatusData<Product> Delete(Expression<Func<Product, bool>> filter);
    }
}

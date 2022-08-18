using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        StatusData<Category> GetRelated(Expression<Func<Category, bool>> filter);
        StatusData<IList<Category>> GetListRelated(Expression<Func<Category, bool>> filter = null);
        StatusData<Category> Get(Expression<Func<Category, bool>> filter);
        StatusData<IList<Category>> GetList(Expression<Func<Category, bool>> filter = null);
        StatusData<Category> Add(Category entity);
        StatusData<Category> Update(Category entity);
        StatusData<Category> Delete(Expression<Func<Category, bool>> filter);
    }
}

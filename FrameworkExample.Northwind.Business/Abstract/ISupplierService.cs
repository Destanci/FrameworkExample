using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface ISupplierService
    {
        StatusData<Supplier> GetRelated(Expression<Func<Supplier, bool>> filter);
        StatusData<IList<Supplier>> GetListRelated(Expression<Func<Supplier, bool>> filter = null);
        StatusData<Supplier> Get(Expression<Func<Supplier, bool>> filter);
        StatusData<IList<Supplier>> GetList(Expression<Func<Supplier, bool>> filter = null);
        StatusData<Supplier> Add(Supplier entity);
        StatusData<Supplier> Update(Supplier entity);
        StatusData<Supplier> Delete(Expression<Func<Supplier, bool>> filter);
    }
}

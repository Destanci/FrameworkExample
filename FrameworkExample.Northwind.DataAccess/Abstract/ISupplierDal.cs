using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface ISupplierDal : IEntityRepository<Supplier>
    {
        Supplier GetWithAllRelated(Expression<Func<Supplier, bool>> filter);
        List<Supplier> GetListWithAllRelated(Expression<Func<Supplier, bool>> filter);
    }
}

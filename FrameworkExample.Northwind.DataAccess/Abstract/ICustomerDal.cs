using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        Customer GetWithAllRelated(Expression<Func<Customer, bool>> filter);
        List<Customer> GetListWithAllRelated(Expression<Func<Customer, bool>> filter);
    }
}

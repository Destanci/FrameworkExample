using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        Order GetWithAllRelated(Expression<Func<Order, bool>> filter);
        List<Order> GetListWithAllRelated(Expression<Func<Order, bool>> filter);
    }
}

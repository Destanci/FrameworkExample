using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IOrder_DetailDal : IEntityRepository<Order_Detail>
    {
        Order_Detail GetWithAllRelated(Expression<Func<Order_Detail, bool>> filter);
        List<Order_Detail> GetListWithAllRelated(Expression<Func<Order_Detail, bool>> filter);
    }
}

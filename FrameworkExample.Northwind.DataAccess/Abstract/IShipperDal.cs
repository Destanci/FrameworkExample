using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IShipperDal : IEntityRepository<Shipper>
    {
        Shipper GetWithAllRelated(Expression<Func<Shipper, bool>> filter);
        List<Shipper> GetListWithAllRelated(Expression<Func<Shipper, bool>> filter);
    }
}

using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface ITerritoryDal : IEntityRepository<Territory>
    {
        Territory GetWithAllRelated(Expression<Func<Territory, bool>> filter);
        List<Territory> GetListWithAllRelated(Expression<Func<Territory, bool>> filter);
    }
}

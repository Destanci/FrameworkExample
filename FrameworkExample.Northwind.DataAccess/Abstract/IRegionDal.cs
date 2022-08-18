using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IRegionDal : IEntityRepository<Region>
    {
        Region GetWithAllRelated(Expression<Func<Region, bool>> filter);
        List<Region> GetListWithAllRelated(Expression<Func<Region, bool>> filter);
    }
}

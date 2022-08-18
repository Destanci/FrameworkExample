using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IRegionService
    {
        StatusData<Region> GetRelated(Expression<Func<Region, bool>> filter);
        StatusData<IList<Region>> GetListRelated(Expression<Func<Region, bool>> filter = null);
        StatusData<Region> Get(Expression<Func<Region, bool>> filter);
        StatusData<IList<Region>> GetList(Expression<Func<Region, bool>> filter = null);
        StatusData<Region> Add(Region entity);
        StatusData<Region> Update(Region entity);
        StatusData<Region> Delete(Expression<Func<Region, bool>> filter);
    }
}

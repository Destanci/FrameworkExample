using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface ITerritoryService
    {
        StatusData<Territory> GetRelated(Expression<Func<Territory, bool>> filter);
        StatusData<IList<Territory>> GetListRelated(Expression<Func<Territory, bool>> filter = null);
        StatusData<Territory> Get(Expression<Func<Territory, bool>> filter);
        StatusData<IList<Territory>> GetList(Expression<Func<Territory, bool>> filter = null);
        StatusData<Territory> Add(Territory entity);
        StatusData<Territory> Update(Territory entity);
        StatusData<Territory> Delete(Expression<Func<Territory, bool>> filter);
    }
}

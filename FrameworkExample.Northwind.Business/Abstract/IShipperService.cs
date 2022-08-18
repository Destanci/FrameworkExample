using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IShipperService
    {
        StatusData<Shipper> GetRelated(Expression<Func<Shipper, bool>> filter);
        StatusData<IList<Shipper>> GetListRelated(Expression<Func<Shipper, bool>> filter = null);
        StatusData<Shipper> Get(Expression<Func<Shipper, bool>> filter);
        StatusData<IList<Shipper>> GetList(Expression<Func<Shipper, bool>> filter = null);
        StatusData<Shipper> Add(Shipper entity);
        StatusData<Shipper> Update(Shipper entity);
        StatusData<Shipper> Delete(Expression<Func<Shipper, bool>> filter);
    }
}

using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IOrder_DetailService
    {
        StatusData<Order_Detail> GetRelated(Expression<Func<Order_Detail, bool>> filter);
        StatusData<IList<Order_Detail>> GetListRelated(Expression<Func<Order_Detail, bool>> filter = null);
        StatusData<Order_Detail> Get(Expression<Func<Order_Detail, bool>> filter);
        StatusData<IList<Order_Detail>> GetList(Expression<Func<Order_Detail, bool>> filter = null);
        StatusData<Order_Detail> Add(Order_Detail entity);
        StatusData<Order_Detail> Update(Order_Detail entity);
        StatusData<Order_Detail> Delete(Expression<Func<Order_Detail, bool>> filter);
    }
}

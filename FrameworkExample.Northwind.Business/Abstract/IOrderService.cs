using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IOrderService
    {
        StatusData<Order> GetRelated(Expression<Func<Order, bool>> filter);
        StatusData<IList<Order>> GetListRelated(Expression<Func<Order, bool>> filter = null);
        StatusData<Order> Get(Expression<Func<Order, bool>> filter);
        StatusData<IList<Order>> GetList(Expression<Func<Order, bool>> filter = null);
        StatusData<Order> Add(Order entity);
        StatusData<Order> Update(Order entity);
        StatusData<Order> Delete(Expression<Func<Order, bool>> filter);
    }
}

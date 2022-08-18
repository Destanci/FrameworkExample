using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface ICustomerService
    {
        StatusData<Customer> GetRelated(Expression<Func<Customer, bool>> filter);
        StatusData<IList<Customer>> GetListRelated(Expression<Func<Customer, bool>> filter = null);
        StatusData<Customer> Get(Expression<Func<Customer, bool>> filter);
        StatusData<IList<Customer>> GetList(Expression<Func<Customer, bool>> filter = null);
        StatusData<Customer> Add(Customer entity);
        StatusData<Customer> Update(Customer entity);
        StatusData<Customer> Delete(Expression<Func<Customer, bool>> filter);
    }
}

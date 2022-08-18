using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface ICustomerDemographicService
    {
        StatusData<CustomerDemographic> GetRelated(Expression<Func<CustomerDemographic, bool>> filter);
        StatusData<IList<CustomerDemographic>> GetListRelated(Expression<Func<CustomerDemographic, bool>> filter = null);
        StatusData<CustomerDemographic> Get(Expression<Func<CustomerDemographic, bool>> filter);
        StatusData<IList<CustomerDemographic>> GetList(Expression<Func<CustomerDemographic, bool>> filter = null);
        StatusData<CustomerDemographic> Add(CustomerDemographic entity);
        StatusData<CustomerDemographic> Update(CustomerDemographic entity);
        StatusData<CustomerDemographic> Delete(Expression<Func<CustomerDemographic, bool>> filter);
    }
}

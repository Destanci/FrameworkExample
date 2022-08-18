using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface ICustomerDemographicDal : IEntityRepository<CustomerDemographic>
    {
        CustomerDemographic GetWithAllRelated(Expression<Func<CustomerDemographic, bool>> filter);
        List<CustomerDemographic> GetListWithAllRelated(Expression<Func<CustomerDemographic, bool>> filter);
    }
}

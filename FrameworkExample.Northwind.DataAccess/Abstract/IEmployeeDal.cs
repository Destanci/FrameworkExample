using FrameworkExample.Core.DataAccess;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        Employee GetWithAllRelated(Expression<Func<Employee, bool>> filter);
        List<Employee> GetListWithAllRelated(Expression<Func<Employee, bool>> filter);
    }
}

using FrameworkExample.Business.ReturnData;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.Business.Abstract
{
    public interface IEmployeeService
    {
        StatusData<Employee> GetRelated(Expression<Func<Employee, bool>> filter);
        StatusData<IList<Employee>> GetListRelated(Expression<Func<Employee, bool>> filter = null);
        StatusData<Employee> Get(Expression<Func<Employee, bool>> filter);
        StatusData<IList<Employee>> GetList(Expression<Func<Employee, bool>> filter = null);
        StatusData<Employee> Add(Employee entity);
        StatusData<Employee> Update(Employee entity);
        StatusData<Employee> Delete(Expression<Func<Employee, bool>> filter);
    }
}

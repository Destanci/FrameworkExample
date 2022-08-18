using FrameworkExample.Core.DataAccess.EntityFramework;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Context;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, NorthwindContext>, IEmployeeDal
    {
        //public EfEmployeeDal(NorthwindContext context) : base(context)
        //{

        //}

        public Employee GetWithAllRelated(Expression<Func<Employee, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Employee>()
                        .Include(x => x.SubEmployees)
                        .Include(x => x.Superior)
                        .Include(x => x.Territories)
                        .Include(x => x.Orders)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Employee> GetListWithAllRelated(Expression<Func<Employee, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Employee>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.SubEmployees)
                        .Include(x => x.Superior)
                        .Include(x => x.Territories)
                        .Include(x => x.Orders)
                        .ToList(); 
            }
        }
    }
}

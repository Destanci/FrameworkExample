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
    public class EfCustomerDemographicDal : EfEntityRepositoryBase<CustomerDemographic, NorthwindContext>, ICustomerDemographicDal
    {
        //public EfCustomerDemographicDal(NorthwindContext context) : base(context)
        //{

        //}

        public CustomerDemographic GetWithAllRelated(Expression<Func<CustomerDemographic, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<CustomerDemographic>()
                        .Include(x => x.Customers)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<CustomerDemographic> GetListWithAllRelated(Expression<Func<CustomerDemographic, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<CustomerDemographic>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Customers)
                        .ToList(); 
            }
        }
    }
}

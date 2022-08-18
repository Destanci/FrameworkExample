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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        //public EfCustomerDal(NorthwindContext context) : base(context)
        //{

        //}

        public Customer GetWithAllRelated(Expression<Func<Customer, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Customer>()
                        .Include(x => x.CustomerDemographics)
                        .Include(x => x.Orders)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Customer> GetListWithAllRelated(Expression<Func<Customer, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Customer>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.CustomerDemographics)
                        .Include(x => x.Orders)
                        .ToList(); 
            }
        }
    }
}

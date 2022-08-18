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
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        //public EfOrderDal(NorthwindContext context) : base(context)
        //{

        //}

        public Order GetWithAllRelated(Expression<Func<Order, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Order>()
                        .Include(x => x.Customer)
                        .Include(x => x.Employee)
                        .Include(x => x.Order_Details)
                        .Include(x => x.Shipper)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Order> GetListWithAllRelated(Expression<Func<Order, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Order>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Customer)
                        .Include(x => x.Employee)
                        .Include(x => x.Order_Details)
                        .Include(x => x.Shipper)
                        .ToList(); 
            }
        }
    }
}

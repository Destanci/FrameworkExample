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
    public class EfOrder_DetailDal : EfEntityRepositoryBase<Order_Detail, NorthwindContext>, IOrder_DetailDal
    {
        //public EfOrder_DetailDal(NorthwindContext context) : base(context)
        //{

        //}

        public Order_Detail GetWithAllRelated(Expression<Func<Order_Detail, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Order_Detail>()
                        .Include(x => x.Order)
                        .Include(x => x.Product)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Order_Detail> GetListWithAllRelated(Expression<Func<Order_Detail, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Order_Detail>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Order)
                        .Include(x => x.Product)
                        .ToList(); 
            }
        }
    }
}

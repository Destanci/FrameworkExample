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
    public class EfShipperDal : EfEntityRepositoryBase<Shipper, NorthwindContext>, IShipperDal
    {
        //public EfShipperDal(NorthwindContext context) : base(context)
        //{

        //}

        public Shipper GetWithAllRelated(Expression<Func<Shipper, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Shipper>()
                        .Include(x => x.Orders)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Shipper> GetListWithAllRelated(Expression<Func<Shipper, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Shipper>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Orders)
                        .ToList(); 
            }
        }
    }
}

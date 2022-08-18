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
    public class EfSupplierDal : EfEntityRepositoryBase<Supplier, NorthwindContext>, ISupplierDal
    {
        //public EfSupplierDal(NorthwindContext context) : base(context)
        //{

        //}

        public Supplier GetWithAllRelated(Expression<Func<Supplier, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Supplier>()
                        .Include(x => x.Products)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Supplier> GetListWithAllRelated(Expression<Func<Supplier, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Supplier>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Products)
                        .ToList(); 
            }
        }
    }
}

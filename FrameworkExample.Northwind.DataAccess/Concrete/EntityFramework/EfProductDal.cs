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
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //public EfProductDal(NorthwindContext context) : base(context)
        //{

        //}

        public Product GetWithAllRelated(Expression<Func<Product, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Product>()
                        .Include(x => x.Category)
                        .Include(x => x.Order_Details)
                        .Include(x => x.Supplier)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Product> GetListWithAllRelated(Expression<Func<Product, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Product>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Category)
                        .Include(x => x.Order_Details)
                        .Include(x => x.Supplier)
                        .ToList(); 
            }
        }
    }
}

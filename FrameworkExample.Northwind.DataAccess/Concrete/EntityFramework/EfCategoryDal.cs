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
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        //public EfCategoryDal(NorthwindContext context) : base(context)
        //{

        //}

        public Category GetWithAllRelated(Expression<Func<Category, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Category>()
                        .Include(x => x.Products)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Category> GetListWithAllRelated(Expression<Func<Category, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Category>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Products)
                        .ToList(); 
            }
        }
    }
}

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
    public class EfRegionDal : EfEntityRepositoryBase<Region, NorthwindContext>, IRegionDal
    {
        //public EfRegionDal(NorthwindContext context) : base(context)
        //{

        //}

        public Region GetWithAllRelated(Expression<Func<Region, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Region>()
                        .Include(x => x.Territories)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Region> GetListWithAllRelated(Expression<Func<Region, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Region>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Territories)
                        .ToList(); 
            }
        }
    }
}

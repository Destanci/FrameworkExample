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
    public class EfTerritoryDal : EfEntityRepositoryBase<Territory, NorthwindContext>, ITerritoryDal
    {
        public Territory GetWithAllRelated(Expression<Func<Territory, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Territory>()
                        .Include(x => x.Region)
                        .Include(x => x.Employees)
                        .SingleOrDefault(filter ?? (x => true)); 
            }
        }

        public List<Territory> GetListWithAllRelated(Expression<Func<Territory, bool>> filter)
        {
            using (var _context = new NorthwindContext())
            {
                return _context.Set<Territory>()
                        .Where(filter ?? (x => true))
                        .Include(x => x.Region)
                        .Include(x => x.Employees)
                        .ToList(); 
            }
        }
    }
}

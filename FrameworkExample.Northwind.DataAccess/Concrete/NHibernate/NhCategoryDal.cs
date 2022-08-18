using FrameworkExample.Core.DataAccess.NHibernate;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }

        public List<Category> GetListWithAllRelated(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category GetWithAllRelated(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

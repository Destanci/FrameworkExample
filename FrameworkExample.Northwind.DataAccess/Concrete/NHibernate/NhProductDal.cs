using FrameworkExample.Core.DataAccess.NHibernate;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FrameworkExample.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }

        public List<Product> GetListWithAllRelated(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Product GetWithAllRelated(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

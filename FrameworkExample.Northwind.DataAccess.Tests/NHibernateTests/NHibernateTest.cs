using FrameworkExample.Northwind.DataAccess.Concrete.NHibernate;
using FrameworkExample.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FrameworkExample.Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.IsTrue(result.Count >= 77);
        }

        [TestMethod]
        public void Get_all_returns_filtered()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(x => x.ProductName.ToLower().Contains("a"));

            Assert.IsTrue(result.Count >= 58 && result.All(x => x.ProductName.ToLower().Contains("a")));
        }

        //[TestMethod]
        //public void Get_all_lazy_loads_many()
        //{
        //    NhProductDal productDal = new NhProductDal(new SqlServerHelper());
        //    var result = productDal.GetList(x => x.ProductName.ToLower().Contains("a"));

        //    Assert.IsTrue(result.Any(x => x.Order_Details.Count > 0));
        //}

        //[TestMethod]
        //public void Get_all_lazy_loads_single()
        //{
        //    NhProductDal productDal = new NhProductDal(new SqlServerHelper());
        //    var result = productDal.GetList(x => x.ProductName.ToLower().Contains("a"));

        //    Assert.IsTrue(result.Any(x => x.Category != null));
        //}
    }
}

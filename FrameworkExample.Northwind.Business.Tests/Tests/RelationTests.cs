using FrameworkExample.Northwind.Business.Concrete.Managers;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FrameworkExample.Northwind.Business.Tests.Tests
{
    [TestClass]
    public class RelationTests
    {
        [TestMethod]
        public void Get_order_with_related()
        {
            var orderManager = new OrderManager(new EfOrderDal());

            var result = orderManager.GetListRelated(x => x.OrderID > 0);

            Assert.IsTrue(result.Entity.First().Shipper != null);
        }

        [TestMethod]
        public void Get_order_with_include()
        {
            var orderManager = new OrderManager(new EfOrderDal());

            var result = orderManager.GetListRelated(x => x.OrderID > 0);

            Assert.IsTrue(result.Entity.First().Shipper != null);
        }
    }
}

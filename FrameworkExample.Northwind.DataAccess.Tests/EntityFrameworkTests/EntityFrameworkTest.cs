using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Context;
using FrameworkExample.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Transactions;

namespace FrameworkExample.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_data()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Get_all_filtered_returns_filtered_data()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(x => x.ProductName.ToLower().Contains("a"));

            Assert.IsFalse(result.Any(x => !x.ProductName.ToLower().Contains("a")));
        }

        [TestMethod]
        public void Get_filtered_returns_filtered_data()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.Get(x => x.ProductID == 1);

            Assert.IsTrue(result.ProductID == 1);
        }

        [TestMethod]
        public void Add_and_remove_product()
        {
            using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    bool error = false;
                    EfProductDal productDal = new EfProductDal();
                    var addResult = productDal.Add(new Product
                    {
                        ProductID = 100,
                        ProductName = "Named Product",
                        UnitPrice = 99999,
                        QuantityPerUnit = "1",
                    });

                    if (addResult == null) error = true;

                    productDal.Delete(addResult);

                    var err = productDal.Get(x => x.ProductID == addResult.ProductID);
                    if (err != null)
                        error = true;

                    txScope.Dispose();
                    Assert.IsFalse(error);
                }
                catch (Exception ex)
                {
                    txScope.Dispose();
                    throw ex;
                } 
            }
        }

        [TestMethod]
        public void Add_new()
        {
            using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    var categoryManager = new EfCategoryDal();

                    categoryManager.Add(new Category()
                    {
                        CategoryName = "TEST",
                        Description = "TEST category you should not see this",
                        Picture = new byte[0],
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    txScope.Dispose();
                }
            }
        }
    }
}

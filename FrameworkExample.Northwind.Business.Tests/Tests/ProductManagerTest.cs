using FluentValidation;
using FrameworkExample.Core.Utilities.Enum;
using FrameworkExample.Northwind.Business.Concrete.Managers;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Context;
using FrameworkExample.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Transactions;

namespace FrameworkExample.Northwind.Business.Tests.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [TestMethod]
        public void Get_all_filtered_products()
        {
            //Mock<IProductDal> mock = new Mock<IProductDal>();
            var productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetList(x => x.ProductName.ToLower().Contains("a"));

            Assert.IsFalse(result.Entity.Any(x => !x.ProductName.ToLower().Contains("a")));
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    //Mock<IProductDal> mock = new Mock<IProductDal>();
                    var productManager = new ProductManager(new EfProductDal());

                    var addResult = productManager.Add(new Product
                    {
                        ProductName = "Some Stuffs",
                        UnitPrice = 99998,
                        QuantityPerUnit = null, // Validation Error cause
                    }); // Expected Exception

                    txScope.Dispose();
                    Assert.IsTrue(addResult.Status != Enums.StatusEnum.Successful
                        && addResult.Exception.GetType() == typeof(ValidationException));
                }
                catch (Exception ex)
                {
                    txScope.Dispose();
                    throw ex;
                } 
            }
        }

        [ExpectedException(typeof(TransactionException))]
        [TestMethod]
        public void Product_transaction_check()
        {
            using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    //Mock<IProductDal> mock = new Mock<IProductDal>();
                    var productManager = new ProductManager(new EfProductDal());

                    int Id = productManager.TransactionalOperation(new Product
                    {
                        ProductName = "Brand New Product",
                        UnitPrice = 99999,
                        QuantityPerUnit = "1",
                    },
                    new Product
                    {
                        ProductName = "Some Stuff",
                        UnitPrice = 99988,
                        QuantityPerUnit = "1",
                    });

                    txScope.Dispose();
                    Assert.IsTrue(productManager.Get(x => x.ProductID == Id) == null);
                }
                catch (Exception ex)
                {
                    txScope.Dispose();
                    throw ex;
                } 
            }
        }

        [TestMethod]
        public void Add_and_remove_product()
        {
            using (var txScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    bool error = false;
                    //Mock<IProductDal> mock = new Mock<IProductDal>();
                    var productManager = new ProductManager(new EfProductDal());

                    var addResult = productManager.Add(new Product
                    {
                        ProductName = "Named Product",
                        UnitPrice = 99999,
                        QuantityPerUnit = "1",
                    });

                    if (addResult.Status != Enums.StatusEnum.Successful) error = true;

                    var deleteResult = productManager.Delete(x => x.ProductID == addResult.Entity.ProductID);

                    if (deleteResult.Status != Enums.StatusEnum.Successful) error = true;

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
    }
}

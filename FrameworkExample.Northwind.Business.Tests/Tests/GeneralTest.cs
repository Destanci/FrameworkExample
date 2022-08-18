using FrameworkExample.Core.Utilities.Enum;
using FrameworkExample.Northwind.Business.Concrete.Managers;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework;
using FrameworkExample.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Transactions;

namespace FrameworkExample.Northwind.Business.Tests.Tests
{
    [TestClass]
    public class GeneralTest
    {
        [TestMethod]
        public void Get_all_models()
        {
            var categoryManager = new CategoryManager(new EfCategoryDal());
            var customerManager = new CustomerManager(new EfCustomerDal());
            var customerDemographicManager = new CustomerDemographicManager(new EfCustomerDemographicDal());
            var employeeManager = new EmployeeManager(new EfEmployeeDal());
            var orderManager = new OrderManager(new EfOrderDal());
            var order_DetailManager = new Order_DetailManager(new EfOrder_DetailDal());
            var productManager = new ProductManager(new EfProductDal());
            var regionManager = new RegionManager(new EfRegionDal());
            var shipperManager = new ShipperManager(new EfShipperDal());
            var supplierManager = new SupplierManager(new EfSupplierDal());
            var territoryManager = new TerritoryManager(new EfTerritoryDal());

            // Should check data integrity via Debug

            var categoryResult = categoryManager.GetList(null);
            var customerResult = customerManager.GetList(null);
            var customerDemographicResult = customerDemographicManager.GetList(null);
            var employeeResult = employeeManager.GetList(null);
            var orderResult = orderManager.GetList(null);
            var order_DetailResult = order_DetailManager.GetList(null);
            var productResult = productManager.GetList(null);
            var regionResult = regionManager.GetList(null);
            var shipperResult = shipperManager.GetList(null);
            var supplierResult = supplierManager.GetList(null);
            var territoryResult = territoryManager.GetList(null);

            Assert.IsTrue(
                categoryResult.Status != Enums.StatusEnum.Error
                && customerResult.Status != Enums.StatusEnum.Error
                && customerDemographicResult.Status != Enums.StatusEnum.Error
                && employeeResult.Status != Enums.StatusEnum.Error
                && orderResult.Status != Enums.StatusEnum.Error
                && order_DetailResult.Status != Enums.StatusEnum.Error
                && productResult.Status != Enums.StatusEnum.Error
                && regionResult.Status != Enums.StatusEnum.Error
                && shipperResult.Status != Enums.StatusEnum.Error
                && supplierResult.Status != Enums.StatusEnum.Error
                && territoryResult.Status != Enums.StatusEnum.Error
                );
        }
    }
}

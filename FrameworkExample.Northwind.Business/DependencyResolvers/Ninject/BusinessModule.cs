using FrameworkExample.Core.DataAccess.NHibernate;
using FrameworkExample.Northwind.Business.Abstract;
using FrameworkExample.Northwind.Business.Concrete.Managers;
using FrameworkExample.Northwind.DataAccess.Abstract;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework;
using FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Context;
using FrameworkExample.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace FrameworkExample.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<NorthwindContext>().ToSelf().InThreadScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICustomerDemographicService>().To<CustomerDemographicManager>().InSingletonScope();
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IOrder_DetailService>().To<Order_DetailManager>().InSingletonScope();
            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IRegionService>().To<RegionManager>().InSingletonScope();
            Bind<IShipperService>().To<ShipperManager>().InSingletonScope();
            Bind<ISupplierService>().To<SupplierManager>().InSingletonScope();
            Bind<ITerritoryService>().To<TerritoryManager>().InSingletonScope();

            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Bind<ICustomerDemographicDal>().To<EfCustomerDemographicDal>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();
            Bind<IOrder_DetailDal>().To<EfOrder_DetailDal>().InSingletonScope();
            Bind<IOrderDal>().To<EfOrderDal>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<IRegionDal>().To<EfRegionDal>().InSingletonScope();
            Bind<IShipperDal>().To<EfShipperDal>().InSingletonScope();
            Bind<ISupplierDal>().To<EfSupplierDal>().InSingletonScope();
            Bind<ITerritoryDal>().To<EfTerritoryDal>().InSingletonScope();


            Bind<NHibernateHelper>().To<SqlServerHelper>().InSingletonScope();
        }
    }
}

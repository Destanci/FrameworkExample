using FluentNHibernate.Mapping;
using FrameworkExample.Northwind.Entities.Concrete;

namespace FrameworkExample.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();

            Id(x => x.ProductID).Column("ProductID");

            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.SupplierID).Column("SupplierID");
            Map(x => x.CategoryID).Column("CategoryID");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice").Precision(19).Scale(4);
            Map(x => x.UnitsInStock).Column("UnitsInStock");
            Map(x => x.UnitsOnOrder).Column("UnitsOnOrder");
            Map(x => x.ReorderLevel).Column("ReorderLevel");
            Map(x => x.Discontinued).Column("Discontinued");

            //HasMany<Supplier>(x => x.Category).KeyColumn("CategoryID");
            //HasMany<Supplier>(x => x.Supplier).KeyColumn("SupplierID");

            //References<Order_Detail>(x => x.Order_Details)
            //    .Column("ProductID")
            //    .Cascade.None();
        }
    }
}

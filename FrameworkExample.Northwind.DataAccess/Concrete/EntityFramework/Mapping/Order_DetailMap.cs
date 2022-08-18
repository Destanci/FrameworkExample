using FrameworkExample.Northwind.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class Order_DetailMap : EntityTypeConfiguration<Order_Detail>
    {
        public Order_DetailMap()
        {
            ToTable(@"Order Details", @"dbo");

            HasKey(x => new { x.OrderID, x.ProductID });
            Property(x => x.OrderID).HasColumnName("OrderID")
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProductID).HasColumnName("ProductID")
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.UnitPrice).HasColumnName("UnitPrice")
                .HasColumnType("money").HasPrecision(19, 4);

            Property(x => x.Quantity).HasColumnName("Quantity");
            Property(x => x.Discount).HasColumnName("Discount");
        }
    }
}

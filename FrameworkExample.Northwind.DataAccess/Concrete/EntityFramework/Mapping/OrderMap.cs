using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable(@"Orders", @"dbo");
            HasKey(x => x.OrderID);

            Property(x => x.CustomerID).HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();
            Property(x => x.EmployeeID).HasColumnName("EmployeeID");
            Property(x => x.OrderDate).HasColumnName("OrderDate");
            Property(x => x.RequiredDate).HasColumnName("RequiredDate");
            Property(x => x.ShippedDate).HasColumnName("ShippedDate");
            Property(x => x.ShipVia).HasColumnName("ShipVia");
            Property(x => x.Freight).HasColumnName("Freight")
                .HasColumnType("money")
                .HasPrecision(19, 4);
            Property(x => x.ShipName).HasColumnName("ShipName")
                .HasMaxLength(40);
            Property(x => x.ShipAddress).HasColumnName("ShipAddress")
                .HasMaxLength(60);
            Property(x => x.ShipCity).HasColumnName("ShipCity")
                .HasMaxLength(15);
            Property(x => x.ShipRegion).HasColumnName("ShipRegion")
                .HasMaxLength(15);
            Property(x => x.ShipPostalCode).HasColumnName("ShipPostalCode")
                .HasMaxLength(10);
            Property(x => x.ShipCountry).HasColumnName("ShipCountry")
                .HasMaxLength(15);

            HasMany(e => e.Order_Details)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}

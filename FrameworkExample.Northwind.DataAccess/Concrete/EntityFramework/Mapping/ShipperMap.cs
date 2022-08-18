using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class ShipperMap : EntityTypeConfiguration<Shipper>
    {
        public ShipperMap()
        {
            ToTable(@"Shippers", @"dbo");
            HasKey(x => x.ShipperID);
            Property(x => x.ShipperID).HasColumnName("ShipperID");

            Property(x => x.CompanyName).HasColumnName("CompanyName")
                .IsRequired().HasMaxLength(40);
            Property(x => x.Phone).HasColumnName("Phone")
                .HasMaxLength(24);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Shipper)
                .HasForeignKey(e => e.ShipVia);
        }
    }
}

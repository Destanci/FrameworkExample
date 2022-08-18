using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class CustomerDemographicMap : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicMap()
        {
            ToTable(@"CustomerDemographics", @"dbo");
            HasKey(x => x.CustomerTypeID);
            Property(e => e.CustomerTypeID)
                .HasColumnName("CustomerTypeID")
                .IsFixedLength()
                .HasMaxLength(10);

            Property(x => x.CustomerDesc).HasColumnName("CustomerDesc")
                .HasColumnType("ntext");

            HasMany(e => e.Customers)
                .WithMany(e => e.CustomerDemographics)
                .Map(m => m.ToTable("CustomerCustomerDemo")
                    .MapLeftKey("CustomerTypeID")
                    .MapRightKey("CustomerID"));
        }
    }
}

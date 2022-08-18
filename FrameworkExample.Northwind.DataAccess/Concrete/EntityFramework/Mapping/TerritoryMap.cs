using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class TerritoryMap : EntityTypeConfiguration<Territory>
    {
        public TerritoryMap()
        {
            ToTable(@"Territories", @"dbo");
            HasKey(x => x.TerritoryID);

            Property(x => x.TerritoryID).HasColumnName("TerritoryID")
                .HasMaxLength(20);
            Property(x => x.TerritoryDescription).HasColumnName("TerritoryDescription")
                .IsRequired().HasMaxLength(50).IsFixedLength();
            Property(x => x.RegionID).HasColumnName("RegionID");

            HasMany(x => x.Employees)
                .WithMany(x => x.Territories);
        }
    }
}

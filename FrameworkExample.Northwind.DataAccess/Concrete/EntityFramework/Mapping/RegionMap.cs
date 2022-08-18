using FrameworkExample.Northwind.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            ToTable(@"Region", @"dbo");
            HasKey(x => x.RegionID);
            Property(x => x.RegionID).HasColumnName("RegionID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.RegionDescription).HasColumnName("RegionDescription")
                .HasMaxLength(50).IsFixedLength();


            HasMany(e => e.Territories)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}

using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryID);
            Property(x => x.CategoryID).HasColumnName("CategoryID");

            Property(x => x.CategoryName).HasColumnName("CategoryName")
                .HasMaxLength(15)
                .IsRequired();
            Property(x => x.Description).HasColumnName("Description")
                .HasColumnType("ntext");
            Property(x => x.Picture).HasColumnName("Picture")
                .HasColumnType("image");


            HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

        }
    }
}

using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable(@"Employees", @"dbo");
            HasKey(x => x.EmployeeID);

            Property(x => x.LastName).HasColumnName("LastName")
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.FirstName).HasColumnName("FirstName")
                .HasMaxLength(10)
                .IsRequired();
            Property(x => x.Title).HasColumnName("Title")
                .HasMaxLength(30);
            Property(x => x.TitleOfCourtesy).HasColumnName("TitleOfCourtesy")
                .HasMaxLength(25);
            Property(x => x.BirthDate).HasColumnName("BirthDate");
            Property(x => x.HireDate).HasColumnName("HireDate");
            Property(x => x.Address).HasColumnName("Address")
                .HasMaxLength(60);
            Property(x => x.City).HasColumnName("City")
                .HasMaxLength(15);
            Property(x => x.Region).HasColumnName("Region")
                .HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName("PostalCode")
                .HasMaxLength(10);
            Property(x => x.Country).HasColumnName("Country")
                .HasMaxLength(15);
            Property(x => x.HomePhone).HasColumnName("HomePhone")
                .HasMaxLength(24);
            Property(x => x.Extension).HasColumnName("Extension")
                .HasMaxLength(4);
            Property(x => x.Photo).HasColumnName("Photo")
                .HasColumnType("image");
            Property(x => x.Notes).HasColumnName("Notes")
                .HasColumnType("ntext");
            Property(x => x.ReportsTo).HasColumnName("ReportsTo");
            Property(x => x.PhotoPath).HasColumnName("PhotoPath")
                .HasMaxLength(255);

            //HasOptional(e => e.Superior)
            //    .WithMany(e => e.SubEmployees)
            //    .HasForeignKey(e => e.ReportsTo);

            HasMany(x => x.Orders)
                .WithRequired(x => x.Employee)
                .HasForeignKey(x => x.EmployeeID);


            HasMany(e => e.SubEmployees)
                .WithOptional(e => e.Superior)
                .HasForeignKey(e => e.ReportsTo);

            HasMany(e => e.Territories)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeeTerritories")
                    .MapLeftKey("EmployeeID")
                    .MapRightKey("TerritoryID"));

        }
    }
}

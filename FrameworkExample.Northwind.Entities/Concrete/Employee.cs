using FrameworkExample.Core.Entities;
using System;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Employee : IEntity
    {
        public Employee()
        {

        }

        public virtual int EmployeeID { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string Title { get; set; }

        public virtual string TitleOfCourtesy { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        public virtual DateTime? HireDate { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string Region { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual string HomePhone { get; set; }

        public virtual string Extension { get; set; }

        public virtual byte[] Photo { get; set; }

        public virtual string Notes { get; set; }

        public virtual int? ReportsTo { get; set; }

        public virtual string PhotoPath { get; set; }


        public virtual ICollection<Employee> SubEmployees { get; set; }

        public virtual Employee Superior { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}

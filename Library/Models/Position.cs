using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }

        public long PositionId { get; set; }
        public string PositionTitle { get; set; }
        public double Salary { get; set; }
        public string Duties { get; set; }
        public string Demands { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Models
{
    public partial class IssuedBook
    {
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnMark { get; set; }
        public long EmpId { get; set; }
        public long ReadId { get; set; }
        public long BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual Reader Read { get; set; }
    }
}

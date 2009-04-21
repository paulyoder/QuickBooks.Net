using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("EmployeeRet")]
    public class Employee : EntityBase
    {
        public Employee()
            : base("Employee")
        { }

        public virtual Address EmployeeAddress { get; set; }
        public virtual string PrintAs { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Pager { get; set; }
        public virtual string PagerPIN { get; set; }
        public virtual string SSN { get; set; }
        public virtual string EmployeeType { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime HiredDate { get; set; }
        public virtual DateTime ReleasedDate { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Reference BillingRateRef { get; set; }
    }
}

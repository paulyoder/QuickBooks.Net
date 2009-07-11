using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    public class EntityBase
    {
        internal EntityBase(string entityType)
        {
            EntityType = entityType;
        }

        public virtual string EntityType { get; set; }
        public virtual string ListID { get; set; }
        public virtual DateTime TimeCreated { get; set; }
        public virtual DateTime TimeModified { get; set; }
        public virtual string EditSequence { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Salutation { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string AltPhone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string Notes { get; set; }
        [XmlElement("DataExtRet")]
        public virtual List<DataExt> DataExt { get; set; }
    }
}

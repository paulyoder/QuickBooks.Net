using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("ClassRet")]
    public class QBClass
    {
        public string ListID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public string EditSequence { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public Reference ParentRef { get; set; }
        public int Sublevel { get; set; }
    }
}

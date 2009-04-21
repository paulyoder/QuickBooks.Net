using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace QuickBooks.Net.Query
{
    public class EntityQuery : 
        CommonQueries<IEntityQuery, EntityBase>, 
        IEntityQuery
    {
        public EntityQuery(IQBSessionInternal session)
            : base(session, "EntityQueryRq", "EntityQueryRs")
        {
            _returnQuery = this;
        }

        protected override IList<EntityBase> XMLtoPOCOList(XElement response)
        {
            var list = new List<EntityBase>();

            var serializer = new XmlSerializer(typeof(Customer));
            foreach (var item in response.Descendants("CustomerRet"))
                list.Add((EntityBase)serializer.Deserialize(new StringReader(item.ToString(SaveOptions.None))));

            serializer = new XmlSerializer(typeof(Employee));
            foreach (var item in response.Descendants("EmployeeRet"))
                list.Add((EntityBase)serializer.Deserialize(new StringReader(item.ToString(SaveOptions.None))));

            serializer = new XmlSerializer(typeof(OtherName));
            foreach (var item in response.Descendants("OtherNameRet"))
                list.Add((EntityBase)serializer.Deserialize(new StringReader(item.ToString(SaveOptions.None))));

            serializer = new XmlSerializer(typeof(Vendor));
            foreach (var item in response.Descendants("VendorRet"))
                list.Add((EntityBase)serializer.Deserialize(new StringReader(item.ToString(SaveOptions.None))));

            return list;
        }
    }
}

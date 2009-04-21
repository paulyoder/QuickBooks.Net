using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public class OtherNameQuery : CommonQueries<IOtherNameQuery, OtherName>, IOtherNameQuery
    {
        public OtherNameQuery(IQBSessionInternal session)
            : base(session, "OtherNameQueryRq", "OtherNameQueryRs")
        {
            _returnQuery = this;
        }
    }
}

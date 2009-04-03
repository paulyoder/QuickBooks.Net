using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public class ClassQuery : CommonQueries<IClassQuery, QBClass>, IClassQuery
    {
        public ClassQuery(IQBSessionInternal session)
            : base(session, "ClassQueryRq", "ClassQueryRs")
        {
            _returnQuery = this;
        }
    }
}

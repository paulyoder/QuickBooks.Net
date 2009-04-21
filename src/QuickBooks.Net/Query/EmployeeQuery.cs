using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public class EmployeeQuery : CommonQueries<IEmployeeQuery, Employee>, IEmployeeQuery
    {
        public EmployeeQuery(IQBSessionInternal session)
            : base(session, "EmployeeQueryRq", "EmployeeQueryRs")
        {
            _returnQuery = this;
        }
    }
}

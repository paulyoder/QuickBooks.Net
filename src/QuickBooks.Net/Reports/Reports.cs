using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Reports
{
    public class Reports : IReports
    {
        protected IQBSessionInternal _session;

        public Reports(IQBSessionInternal session)
        {
            _session = session;
        }

        protected ICustomDetailReport _customDetailReport;
        public ICustomDetailReport CustomDetailReport
        {
            get
            {
                if (_customDetailReport == null)
                    _customDetailReport = new CustomDetailReport(_session);
                return _customDetailReport;
            }
        }
    }
}

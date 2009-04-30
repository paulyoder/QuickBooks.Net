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
        public virtual ICustomDetailReport CustomDetailReport
        {
            get
            {
                if (_customDetailReport == null)
                    _customDetailReport = new CustomDetailReport(_session);
                return _customDetailReport;
            }
        }

        protected ICustomSummaryReport _customSummaryReport;
        public virtual ICustomSummaryReport CustomSummaryReport
        {
            get
            {
                if (_customSummaryReport == null)
                    _customSummaryReport = new CustomSummaryReport(_session);
                return _customSummaryReport;
            }
        }

        protected IGeneralDetailReport _generalDetailReport;
        public virtual IGeneralDetailReport GeneralDetailReport
        {
            get
            {
                if (_generalDetailReport == null)
                    _generalDetailReport = new GeneralDetailReport(_session);
                return _generalDetailReport;
            }
        }

        protected IGeneralSummaryReport _generalSummaryReport;
        public virtual IGeneralSummaryReport GeneralSummaryReport
        {
            get
            {
                if (_generalSummaryReport == null)
                    _generalSummaryReport = new GeneralSummaryReport(_session);
                return _generalSummaryReport;
            }
        }

        protected IPayrollDetailReport _payrollDetailReport;
        public virtual IPayrollDetailReport PayrollDetailReport
        {
            get
            {
                if (_payrollDetailReport == null)
                    _payrollDetailReport = new PayrollDetailReport(_session);
                return _payrollDetailReport;
            }
        }

        protected IPayrollSummaryReport _payrollSummaryReport;
        public virtual IPayrollSummaryReport PayrollSummaryReport
        {
            get
            {
                if (_payrollSummaryReport == null)
                    _payrollSummaryReport = new PayrollSummaryReport(_session);
                return _payrollSummaryReport;
            }
        }
    }
}

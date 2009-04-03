using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net
{
    /// <summary>
    /// QuickBooks Exception
    /// </summary>
    public class QBException : Exception
    {
        public virtual int StatusCode { get; protected set; }

        public QBException(string message)
            : this(message, 0)
        { }

        public QBException(string message, string statusCode)
            : this(message, Convert.ToInt32(statusCode))
        { }

        public QBException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

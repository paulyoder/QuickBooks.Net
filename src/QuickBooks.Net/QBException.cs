using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuickBooks.Net
{
    /// <summary>
    /// QuickBooks Exception
    /// </summary>
    public class QBException : Exception
    {
        public virtual string StatusCode { get; protected set; }
        public virtual XDocument QBXML { get; protected set; }

        public QBException(string message)
            : this(message, "0")
        { }

        public QBException(string message, string statusCode)
            : this(message, statusCode, null)
        { }

        public QBException(string message, string statusCode, XDocument qbxml)
            : base(message)
        {
            StatusCode = statusCode;
            QBXML = qbxml;
        }
    }
}

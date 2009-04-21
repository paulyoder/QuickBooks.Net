using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QBXMLRP2Lib;
using System.Xml.Linq;
using log4net;
using System.Reflection;

namespace QuickBooks.Net
{
    public class QBSessionFactory : IQBSessionFactory
    {
        private ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected IQBSession _session;
        protected string _sessionTicket;
        protected RequestProcessor2 _requestProcessor;
        protected string _appId;
        protected string _appName;
        protected string _qbXmlVersion;
        protected QBXMLRPConnectionType _connectionType;
        protected string _fileName;
        protected QBFileMode _fileMode;
        protected bool _connectionIsOpen;

        public QBSessionFactory(string appName)
            : this(appName, "", "7.0", "", FileMode.DoNotCare, ConnectionType.LocalQBD)
        { }

        public QBSessionFactory(string appName, string appId, string qbXmlVersion, string fileName, FileMode fileMode, ConnectionType connectionType)
        {
            _log.Info("Instantiating new QBSession Factory");
            _log.InfoFormat("App Name: {0}", appName);
            _log.InfoFormat("App Id: {0}", appId);
            _log.InfoFormat("QBXML Version: {0}", qbXmlVersion);
            _log.InfoFormat("File Name: {0}", fileName);
            _log.InfoFormat("File Mode: {0}", Enum.GetName(typeof(FileMode), fileMode));
            _log.InfoFormat("Connection Type: {0}", Enum.GetName(typeof(ConnectionType), connectionType));

            _requestProcessor = new RequestProcessor2Class();
            _appName = appName;
            _appId = appId;
            _fileName = fileName;
            _qbXmlVersion = qbXmlVersion;
            //Converting enums to QBXMLRP2Lib namespace enums
            _fileMode = QBFileMode.qbFileOpenDoNotCare;
            _connectionType = QBXMLRPConnectionType.localQBD;
            //_fileMode = (QBFileMode)Enum.Parse(
            //    typeof(QBFileMode),
            //    Enum.GetName(typeof(FileMode), fileMode));
            //_connectionType = (QBXMLRPConnectionType)Enum.Parse(
            //    typeof(QBXMLRPConnectionType),
            //    Enum.GetName(typeof(ConnectionType), connectionType));

            _connectionIsOpen = false;
        }

        public IQBSession OpenSession()
        {
            if (!_connectionIsOpen)
            {
                if (_log.IsDebugEnabled)
                    _log.Debug("Opening Connection");
                _requestProcessor.OpenConnection(_appId, _appName);
                _connectionIsOpen = true;
            }

            _sessionTicket = _requestProcessor.BeginSession(_fileName, _fileMode);
            _session = new QBSession(this, _qbXmlVersion, _sessionTicket);
            return _session;
        }

        public void Dispose()
        {
            CloseSession();
        }

        public void CloseSession()
        {
            if (_connectionIsOpen)
            {
                if (_session != null)
                {
                    if (_log.IsDebugEnabled)
                        _log.DebugFormat("Closing Session Ticket {0}", _sessionTicket);
                    _requestProcessor.EndSession(_sessionTicket);
                    _session = null;
                    _sessionTicket = null;
                }
                if (_log.IsDebugEnabled)
                    _log.Debug("Closing Connection");
                _requestProcessor.CloseConnection();
                _connectionIsOpen = false;
            }
        }

        internal XElement ProcessRequest(string ticket, string inputRequest)
        {
            return XElement.Parse(_requestProcessor.ProcessRequest(ticket, inputRequest));
        }
    }
}

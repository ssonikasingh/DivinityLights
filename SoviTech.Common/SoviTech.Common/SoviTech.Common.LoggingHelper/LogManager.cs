using System;

using log4net.Config;
using SoviTech.Common.Contracts;

namespace SoviTech.Common.LogHelper
{
    public class LogManager : ILogManager
    {
        #region "Private Fields"
        /// <summary>
        /// Log4Net formatter
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(LogManager));

        /// <summary>
        /// Wether already configured or not
        /// </summary>
        private readonly bool _isConfigured;

        /// <summary>
        /// Object for locking
        /// </summary>
        private static readonly object SyncRoot = new object();

        #endregion

        /// <summary>
        /// Is Debug Enabled
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        /// <summary>
        /// Is Error Enabled
        /// </summary>
        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }

        /// <summary>
        /// Is Fatal Enabled
        /// </summary>
        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }

        /// <summary>
        /// Is Info Enabled
        /// </summary>
        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }

        /// <summary>
        /// Is Warn Enabled
        /// </summary>
        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }

        /// <summary>
        /// Reads the logging config file & initializes the logging framework 
        /// </summary>
        public LogManager()
        {
            if (!_isConfigured)
            {
                lock (SyncRoot)
                {
                    XmlConfigurator.Configure();

                    _isConfigured = true;
                }
            }
        }

        /// <summary>
        /// Start Logical Grouping
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Guid StartLogicalGrouping(string groupName)
        {
            return StartLogicalGrouping(groupName, null);

        }

        /// <summary>
        /// Start Logical Grouping
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Guid StartLogicalGrouping(string groupName, string guid)
        {
            Utils.StartLogicalOperation(groupName);
            //Guid prevGuid = Utils.GetActivityId();
            Guid tempGuid;
            if (string.IsNullOrWhiteSpace(guid))
            {
                tempGuid = Guid.NewGuid();
            }
            else
            {
                tempGuid = new Guid(guid);
            }

            Utils.SetActivityId(tempGuid);
            return tempGuid;
        }

        /// <summary>
        /// Ends the log grouping.
        /// </summary>
        /// <param name="guid">GUID of previous group. Guid returned by StartLogGrouping method.</param>
        public void EndLogicalGrouping(Guid guid)
        {
            Utils.StopLogicalOperation();
            //Utils.SetActivityId(Guid.NewGuid());
        }

        /// <summary>
        /// Gets the tracer.
        /// </summary>
        /// <returns>
        /// The tracer
        /// </returns>
        public ITracer GetTracer()
        {
            return new LogTracer(this);
        }

        /// <summary>
        /// Write Debug Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void LogDebug(string message)
        {
            string activityId = string.Empty;
            if (Utils.GetActivityId() != Guid.Empty)
            {
                activityId = Utils.GetActivityId().ToString();
            }

            //TODO
            _logger.DebugFormat("{0}~{1}", "ActivityId:" + activityId, message);
        }

        /// <summary>
        /// Handles the exception and logs error
        /// </summary>
        /// <param name="ex">
        /// Exception
        /// </param>
        public void LogException(Exception ex)
        {
            string activityId = string.Empty;
            if (Utils.GetActivityId() != Guid.Empty)
            {
                activityId = Utils.GetActivityId().ToString();
            }

            LogException(ex, activityId);
        }

        /// <summary>
        /// Handles the exception and logs error
        /// </summary>
        /// <param name="ex">
        /// Exception
        /// </param>
        /// <param name="activityId"></param>
        public void LogException(Exception ex, string activityId)
        {
            _logger.ErrorFormat("{0}~{1}", "ActivityId:" + activityId, ex);
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void LogException(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Handle the execption and message
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="ex">
        /// </param>
        public void LogException(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }

        /// <summary>
        /// Write Info Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void LogInfo(string message)
        {
            string activityId = string.Empty;
            if (Utils.GetActivityId() != Guid.Empty)
            {
                activityId = Utils.GetActivityId().ToString();
            }

            LogInfo(message, activityId);
        }

        /// <summary>
        /// Write Info Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="activityId"></param>
        public void LogInfo(string message, string activityId)
        {
            _logger.InfoFormat("{0}~{1}", "ActivityId:" + activityId, message);
        }


    }
}

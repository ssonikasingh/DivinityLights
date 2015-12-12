using System;

namespace SoviTech.Common.Contracts
{
    /// <summary>
    /// Log Manager Interface
    /// </summary>
    public interface ILogManager
    {

        /// <summary>
        /// Is Debug Enabled
        /// </summary>
        bool IsDebugEnabled { get; }
        
        /// <summary>
        /// Is Error Enabled
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Is Fatal Enabled
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Is Info Enabled
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Is Warn Enabled
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Start Logical Grouping
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        Guid StartLogicalGrouping(string groupName);

        /// <summary>
        /// Start Logical Grouping
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        Guid StartLogicalGrouping(string groupName, string guid);


        /// <summary>
        /// Ends the log grouping.
        /// </summary>
        /// <param name="guid">GUID of previous group. Guid returned by StartLogGrouping method.</param>
        void EndLogicalGrouping(Guid guid);


        /// <summary>
        /// Gets the tracer.
        /// </summary>
        /// <returns>
        /// The tracer
        /// </returns>
        ITracer GetTracer();

        /// <summary>
        /// Write Debug Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void LogDebug(string message);

        /// <summary>
        /// Handles the exception and logs error
        /// </summary>
        /// <param name="ex">
        /// Exception
        /// </param>
        void LogException(Exception ex);

        /// <summary>
        /// Handles the exception and logs error for given activity id
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="activityId"></param>
        void LogException(Exception ex, string activityId);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void LogException(string message);

        /// <summary>
        /// Handle the execption and message
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="ex">
        /// </param>
        void LogException(string message, Exception ex);

        /// <summary>
        /// Write Info Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void LogInfo(string message);

        /// <summary>
        /// Write Info Data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="activityId"></param>
        void LogInfo(string message, string activityId);
    }
}

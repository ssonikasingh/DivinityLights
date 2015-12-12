using System;
using System.Diagnostics;

namespace SoviTech.Common.LogHelper
{
    /// <summary>
    /// Utility class for Log Helper
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Gets the activity id.
        /// </summary>
        /// <returns>the activity id</returns>
        public static Guid GetActivityId()
        {
            return Trace.CorrelationManager.ActivityId;
        }

        /// <summary>
        /// Sets the activity id.
        /// </summary>
        /// <param name="activityId">The activity id.</param>
        /// <returns>The activity id</returns>
        public static Guid SetActivityId(Guid activityId)
        {
            return Trace.CorrelationManager.ActivityId = activityId;
        }

        /// <summary>
        /// Starts the logical operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        public static void StartLogicalOperation(string operation)
        {
            Trace.CorrelationManager.StartLogicalOperation(operation);
        }

        /// <summary>
        /// Stops the logical operation.
        /// </summary>
        public static void StopLogicalOperation()
        {
            Trace.CorrelationManager.StopLogicalOperation();
        }
    }
}

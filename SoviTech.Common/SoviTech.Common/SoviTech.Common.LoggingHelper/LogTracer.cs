using System.Diagnostics;
using System.Globalization;
using SoviTech.Common.Contracts;

namespace SoviTech.Common.LogHelper
{
    /// <summary>
    /// Represnts enterprise library tracer
    /// </summary>
    public class LogTracer : ITracer
    {
        #region Fields

        private const string TraceEndMessage = "Tracing Ended For {0}";
        private const string TraceStartMessage = "Tracing Started For {0}";

        private Stopwatch _stopwatch;
        private string _traceGroup;
        private long _tracingStartTicks;

        private readonly ILogManager _logManager;

        #endregion Fields

        #region Constructors

        public LogTracer(ILogManager logManager)
        {
            _logManager = logManager;
        }

        #endregion Constructors

        #region Methods


        /// <summary>
        /// Starts the tracing.
        /// </summary>
        /// <param name="group">The trace group.</param>
        public void StartTracing(string group)
        {
            if (_logManager.IsDebugEnabled || _logManager.IsInfoEnabled)
            {
                _traceGroup = group;
                _stopwatch = Stopwatch.StartNew();
                _tracingStartTicks = Stopwatch.GetTimestamp();

                //string message = string.Format(CultureInfo.CurrentCulture, TraceStartMessage,
                //    " Method " + GetExecutingMethodName());

                //_logManager.LogDebug(message + " Ticks: " + _tracingStartTicks + " TraceGroup:" + _traceGroup);

                string message = string.Format(CultureInfo.CurrentCulture, TraceStartMessage,
                    " Method " + _traceGroup);


                _logManager.LogDebug(message + " Ticks: " + _tracingStartTicks);
            }
        }

        /// <summary>
        /// Ends the tracing.
        /// </summary>
        public void EndTracing()
        {
            if (_logManager.IsDebugEnabled || _logManager.IsInfoEnabled)
            {
                decimal secondsElapsed = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Stop();
                long tracingEndTicks = Stopwatch.GetTimestamp();

                //string message = string.Format(CultureInfo.CurrentCulture, TraceEndMessage,
                //    " Method " + GetExecutingMethodName());

                //_logManager.LogDebug(message + " Ticks: " + tracingEndTicks + " TraceGroup: " + _traceGroup +
                //                     " MiliSecondElapsed:" + secondsElapsed);
                
                string message = string.Format(CultureInfo.CurrentCulture, TraceEndMessage,
                    " Method: " + _traceGroup);

                _logManager.LogDebug(message + " Ticks: " + tracingEndTicks + 
                                     " MiliSecondElapsed:" + secondsElapsed);
            }
        }


        ///// <summary>
        ///// Gets the name of the executing method.
        ///// </summary>
        ///// <returns>the method name</returns>
        //private string GetExecutingMethodName()
        //{
        //    var stackTrace = new StackTrace();
        //    var stackFrames = stackTrace.GetFrames();

        //    if (stackFrames != null)
        //    {
        //        int count = stackFrames.TakeWhile(fr => !fr.GetMethod().Name.Equals("EndTracing") && !fr.GetMethod().Name.Equals("StartTracing")).Count();

        //        MethodBase methodBase = stackFrames[count + 1].GetMethod();
        //        if (methodBase.ReflectedType != null)
        //            return string.Concat(methodBase.ReflectedType.FullName, ".", methodBase.Name);
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// Gets the seconds elapsed.
        ///// </summary>
        ///// <param name="milliseconds">The milliseconds.</param>
        ///// <returns>the seconds elapsed</returns>
        //private decimal GetSecondsElapsed(long milliseconds)
        //{
        //    decimal result = Convert.ToDecimal(milliseconds) / 1000m;
        //    return Math.Round(result, 6);
        //}

        #endregion Methods
    }
}

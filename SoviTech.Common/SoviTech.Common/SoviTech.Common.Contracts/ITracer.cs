namespace SoviTech.Common.Contracts
{
    /// <summary>
    /// Represnts tracer interface. Can be used for method and activity tracing 
    /// </summary>
    public interface ITracer
    {
        #region Methods

        /// <summary>
        /// Ends the tracing.
        /// </summary>
        void EndTracing();

        /// <summary>
        /// Starts the tracing.
        /// </summary>
        /// <param name="traceGroup">The trace group.</param>
        void StartTracing(string traceGroup);

        #endregion Methods
    }
}

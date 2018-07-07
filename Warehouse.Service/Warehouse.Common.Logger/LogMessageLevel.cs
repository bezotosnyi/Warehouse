// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogMessageLevel.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the MessageLevel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Common.Logger
{
    /// <summary>
    /// The message level.
    /// </summary>
    public enum LogMessageLevel
    {
        /// <summary>
        /// The fatal.
        /// </summary>
        Fatal,

        /// <summary>
        /// The error.
        /// </summary>
        Error,

        /// <summary>
        /// The warning.
        /// </summary>
        Warning,

        /// <summary>
        /// The info.
        /// </summary>
        Info,

        /// <summary>
        /// The debug.
        /// </summary>
        Debug
    }
}
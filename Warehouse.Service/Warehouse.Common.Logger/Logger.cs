// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Common.Logger
{
    using System;

    using log4net;

    /// <summary>
    /// The logger.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog LogMessage;

        /// <summary>
        /// Initializes static members of the <see cref="Logger"/> class.
        /// </summary>
        static Logger()
        {
            LogMessage = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// The log.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="messageLevel">
        /// The message level.
        /// </param>
        public static void Log(object message, LogMessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case LogMessageLevel.Fatal:
                    LogMessage.Fatal(message);
                    break;

                case LogMessageLevel.Error:
                    LogMessage.Error(message);
                    break;

                case LogMessageLevel.Warning:
                    LogMessage.Warn(message);
                    break;

                case LogMessageLevel.Info:
                    LogMessage.Info(message);
                    break;

                case LogMessageLevel.Debug:
                    LogMessage.Debug(message);
                    break;
            }
        }

        /// <summary>
        /// The log.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="messageLevel">
        /// The message level.
        /// </param>
        public static void Log(object message, Exception exception, LogMessageLevel messageLevel)
        {
            switch (messageLevel)
            {
                case LogMessageLevel.Fatal:
                    LogMessage.Fatal(message, exception);
                    break;

                case LogMessageLevel.Error:
                    LogMessage.Error(message, exception);
                    break;

                case LogMessageLevel.Warning:
                    LogMessage.Warn(message, exception);
                    break;

                case LogMessageLevel.Info:
                    LogMessage.Info(message, exception);
                    break;

                case LogMessageLevel.Debug:
                    LogMessage.Debug(message, exception);
                    break;
            }
        }
    }
}
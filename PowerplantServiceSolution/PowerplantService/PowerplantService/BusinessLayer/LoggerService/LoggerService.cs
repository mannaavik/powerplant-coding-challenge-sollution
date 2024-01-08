using System;
using PowerplantService.BusinessLayer.Intefaces;

namespace PowerplantService.BusinessLayer.LoggerService
{
    /// <summary>
    /// Class to manage the logging
    /// </summary>
	public class LoggerService : ILoggerService
	{
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Log errors
        /// </summary>
        /// <param name="message">message to log</param>
        public void LogError(string message)
        {
            this._logger.LogError(message);
        }
    }
}


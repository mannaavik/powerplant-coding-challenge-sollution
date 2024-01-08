using System;
namespace PowerplantService.BusinessLayer.Intefaces
{
    /// <summary>
    /// Interface for logging
    /// </summary>
	public interface ILoggerService
	{
        /// <summary>
        /// Log errors
        /// </summary>
        /// <param name="message">messages</param>
        void LogError(string message);
    }
}


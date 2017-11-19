namespace SmtpServer
{
    public interface ILogger
    {
        /// <summary>
        /// Log a verbose message.
        /// </summary>
        /// <param name="format">The message format.</param>
        /// <param name="args">The message arguments.</param>
        void LogVerbose(string format, params object[] args);
    }
}
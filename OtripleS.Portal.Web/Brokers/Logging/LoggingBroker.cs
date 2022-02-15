namespace OtripleS.Portal.Web.Brokers.Logging
{
    public class LoggingBroker : ILoggingBroker
    {
        readonly ILogger logger;

        public LoggingBroker(ILogger logger) =>
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public void LogCritical(Exception exception) => this.logger.LogCritical(exception, exception.Message);
        public void LogDebug(string message) => this.logger.LogDebug(message);
        public void LogError(Exception exception) => this.logger.LogError(exception, exception.Message);
        public void LogInformation(string message) => this.logger.LogInformation(message);
        public void LogTrace(string message) => this.logger.LogTrace(message);
        public void LogWarning(string message) => this.logger.LogWarning(message);
    }
}
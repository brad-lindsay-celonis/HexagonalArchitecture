using HexagonalDomain.Logging;

namespace HexagonalServices.Logging
{
    public class LoggingService : ILoggingService
    {
        private ILoggingAdapter _loggingAdapter;

        public LoggingService(ILoggingAdapter loggingAdapter)
        {
            _loggingAdapter = loggingAdapter;
        }

        public void LogError(string message) => _loggingAdapter.LogError(message);

        public void LogInfo(string message) => _loggingAdapter.LogInfo(message);
    }
}

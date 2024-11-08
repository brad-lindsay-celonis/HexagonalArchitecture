using HexagonalServices.Logging;
using Microsoft.Extensions.Logging;

namespace HexagonalClient.Adapters
{
    internal class NLogAdapter : ILoggingAdapter
    {
        private readonly ILogger<NLogAdapter> _nlog_Logger;

        public NLogAdapter(ILogger<NLogAdapter> nlog_logger)
        {
            _nlog_Logger = nlog_logger;
        }

        public void LogError(string message) => _nlog_Logger.LogError(message);

        public void LogInfo(string message) => _nlog_Logger.LogInformation(message);
    }
}

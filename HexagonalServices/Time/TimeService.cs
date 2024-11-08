using HexagonalDomain.Logging;
using HexagonalDomain.Time;

namespace HexagonalServices.Time
{
    public class TimeService : ITimeService
    {
        private readonly ILoggingService _loggingService;

        public TimeService(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void TellTime()
        {
            _loggingService.LogInfo($"It's {DateTime.Now.ToLocalTime()}");
        }
    }
}

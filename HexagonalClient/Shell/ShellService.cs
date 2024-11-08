using HexagonalDomain.Logging;
using HexagonalDomain.Settings;
using HexagonalDomain.Time;

namespace HexagonalClient.Shell
{
    internal class ShellService : IShellService
    {
        private readonly ILoggingService _loggingService;
        private readonly ITimeService _timeService;
        private readonly ISettingsService _settingsService;

        public ShellService(ILoggingService loggingService, ITimeService timeService, ISettingsService settingsService)
        {
            _loggingService = loggingService;
            _timeService = timeService;
            _settingsService = settingsService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Write something to NLog through ILoggingService:");

                var input = Console.ReadLine();
                if (input != null)
                {
                    _loggingService.LogInfo($"Got: {input}");
                    if (input == "time")
                        _timeService.TellTime();
                    if (input == "foo")
                    {
                        var setting = _settingsService.GetSetting("foo");
                        _loggingService.LogInfo(setting);
                    }
                }
            }
        }
    }
}

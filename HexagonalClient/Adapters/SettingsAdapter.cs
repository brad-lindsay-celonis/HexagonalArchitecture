using HexagonalDomain.Logging;
using HexagonalServices.Settings;

namespace HexagonalClient.Adapters
{
    internal class SettingsAdapter : ISettingsAdapter
    {
        private readonly ILoggingService _loggingService;

        public SettingsAdapter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public string GetSetting(string key)
        {
            _loggingService.LogInfo("Settings Queried");
            if (key == "foo")
                return "bar";
            return "";
        }
    }
}

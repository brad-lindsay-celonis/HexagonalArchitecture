using HexagonalDomain.Settings;

namespace HexagonalServices.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsAdapter _settingsAdapter;

        public SettingsService(ISettingsAdapter settingsAdapter)
        {
            _settingsAdapter = settingsAdapter;
        }

        public string GetSetting(string key) => _settingsAdapter.GetSetting(key);
    }
}

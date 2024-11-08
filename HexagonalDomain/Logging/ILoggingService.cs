namespace HexagonalDomain.Logging
{
    public interface ILoggingService
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}

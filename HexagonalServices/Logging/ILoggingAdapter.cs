namespace HexagonalServices.Logging
{
    public interface ILoggingAdapter
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}

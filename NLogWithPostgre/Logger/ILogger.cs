namespace Logger
{
    public interface ILogger
    {
        Task LogError(string error);
        Task LogInformation(string error);
        Task LogTrace(string error);
    }
}

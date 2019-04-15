namespace Communication.DataSource
{
    public interface IOpenSubtitlesClient
    {
        string Send<T>(T request);
    }
}

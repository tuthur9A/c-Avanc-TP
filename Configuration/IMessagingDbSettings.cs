namespace TP.Configurations
{
    /// <summary>
    /// Messaging database Settings interface
    /// </summary>
    public interface IMessagingDbSettings
    {
#pragma warning disable 1591
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        bool SslProtocols { get; set; }
    }
}

namespace TP.Configurations
{
    /// <summary>
    /// Messaging database Settings
    /// </summary>
    public class MessagingDbSettings : IMessagingDbSettings
    {
        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database name
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Ssl protocols
        /// </summary>
        public bool SslProtocols { get; set; }
    }
}

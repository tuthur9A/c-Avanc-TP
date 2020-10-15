using System.Security.Authentication;
using MongoDB.Driver;
using TP.Collection;
using TP.Configurations;

namespace TP.Data
{
    /// <summary>
    /// Messaging database context
    /// </summary>
    public class MessagingDbContext
    {
        private readonly IMongoDatabase _database = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        public MessagingDbContext(IMessagingDbSettings settings)
        {
            MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(
                new MongoUrl(settings.ConnectionString)
            );

            if (settings.SslProtocols)
            {
                mongoClientSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            }

            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.DatabaseName);
        }

        /// <summary>
        /// Scenario collection
        /// </summary>
        /// <value></value>
        public IMongoCollection<BookCollection> BookCollection
        {
            get
            {
                return _database.GetCollection<BookCollection>("books");
            }
        }
        /// <summary>
        /// Scenario collection
        /// </summary>
        /// <value></value>
        public IMongoCollection<ShelvesCollection> ShelvesCollection
        {
            get
            {
                return _database.GetCollection<ShelvesCollection>("shelves");
            }
        }
    }
}

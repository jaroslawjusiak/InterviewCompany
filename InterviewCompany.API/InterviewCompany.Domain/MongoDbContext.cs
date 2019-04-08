using InterviewCompany.Domain.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InterviewCompany.Domain
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db = null;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Invoice> Invoices
        {
            get
            {
                return _db.GetCollection<Invoice>("Invoices");
            }
        }

        public IMongoCollection<Currency> Currencies
        {
            get
            {
                return _db.GetCollection<Currency>("Currencies");
            }
        }
    }
}

using MongoDB.Driver.Core.Configuration;

namespace CrudContatos.Models
{
    public class ContatoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ContatosCollectionName { get; set; } = null!;

    }
}

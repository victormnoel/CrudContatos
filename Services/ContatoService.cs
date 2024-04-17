using CrudContatos.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudContatos.Services
{
    public class ContatoService
    {
        private readonly IMongoCollection<Contato> _contatosCollection;

        public ContatoService(IOptions<ContatoDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _contatosCollection = mongoDatabase.GetCollection<Contato>(options.Value.ContatosCollectionName);
        }

        public async Task<List<Contato>> GetAllAsync()
        {
            return await _contatosCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Contato?> GetByIdAsync(Guid id)
        {
            return await _contatosCollection.Find(contato => contato.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Contato contato)
        {
            await _contatosCollection.InsertOneAsync(contato);
        }

        public async Task UpdateAsync(Guid id, Contato novoContato)
        {
            await _contatosCollection.ReplaceOneAsync(contato => contato.Id == id, novoContato);
        }
        public async Task RemoveAsync(Guid id)
        {
            await _contatosCollection.DeleteOneAsync(contato => contato.Id == id);
        }
       
    }
}

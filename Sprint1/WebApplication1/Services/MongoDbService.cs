using MongoDB.Driver;

namespace WebApplication1.Services
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazenar a configuração da aplicação
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Armazena uma ref ao MongoDb
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Contém a configuração para acesso ao DB
        /// </summary>
        /// <param name="configuration">Objeto contendo toda a config da aplicação</param>
        public MongoDbService(IConfiguration configuration)
        {
            //atribui a config recebida em _config
            _config = configuration;

            //Acessa a string de conexão
            var connectionString = _config.GetConnectionString("DbConnection");
            
            //Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client 
            var mongoClient = new MongoClient(mongoUrl);

            //Obtém a ref ao MongoDb
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Prop para acessar o db => retorna os dados em _Database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}

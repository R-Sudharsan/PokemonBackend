using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace PokemonBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
            var connectionString = "mongodb+srv://sudhrravi:wKuyXFGQHyqRKMcY@cluster0.ejaldz8.mongodb.net/?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("project_vx_pokemon");
            _pokemonCollection = database.GetCollection<Pokemon>("project_vx_ff");
        }

        [HttpGet(Name = "GetPokemon")]
        public IEnumerable<Pokemon> Get()
        {
            // Use the Find method to retrieve all documents in the collection
            var pokemonList = _pokemonCollection.Find(p => true).ToList();
            return pokemonList;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace PokemonBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly List<Pokemon> _pokemonList;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
            var jsonData = System.IO.File.ReadAllText("data.json");
            _pokemonList = JsonSerializer.Deserialize<List<Pokemon>>(jsonData);
        }

        [HttpGet(Name = "GetPokemon")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pokemonList); // Return 200 with the data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving data.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("images/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string imagesPath = Path.Combine(baseDirectory, "images", imageName);

                _logger.LogInformation($"Image Path: {imagesPath}");

                if (System.IO.File.Exists(imagesPath))
                {
                    _logger.LogInformation($"Image Found. Returning: {imagesPath}");
                    return PhysicalFile(imagesPath, "image/jpg");
                }

                _logger.LogInformation("Image Not Found.");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving image.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
}

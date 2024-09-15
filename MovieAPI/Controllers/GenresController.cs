using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTOs;
using MovieAPI.Models;
using MovieAPI.Repository.IRepository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepo;
        public GenresController(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genreRepo.GetAllAsync();

            return Ok(genres);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);

            if (genre == null)
                return NotFound($"Genre with id: {id} was not found!");

            return Ok(genre);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] GenreDTO dto)
        {
            var genre = new Genre
            {
                Title = dto.Title
            };

            await _genreRepo.CreateAsync(genre);

            return Ok(genre);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GenreDTO dto)
        {
            var genre = await _genreRepo.GetByIdAsync(id);

            if (genre == null)
                return NotFound($"Genre with id: {id} was not found!");

            genre.Title = dto.Title;

            _genreRepo.Update(genre);

            return Ok(genre);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);

            if (genre == null)
                return NotFound($"Genre with id: {id} was not found!");

            _genreRepo.Delete(genre);

            return Ok(genre);
        }
    }
}

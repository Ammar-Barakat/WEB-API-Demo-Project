using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTOs;
using MovieAPI.Models;
using MovieAPI.Repository.IRepository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IGenreRepository _genreRepo;

        private List<string> _allowedExtensions = new List<string> { ".jpg", ".png" };
        private long _allowedMaxPosterSize = 1048576;

        public MoviesController(IMovieRepository movieRepo, IGenreRepository genreRepo)
        {
            _movieRepo = movieRepo;
            _genreRepo = genreRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _movieRepo.GetAllAsync();

            return Ok(movies);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var movie = await _movieRepo.GetByIdAsync(id);

            if (movie == null)
                return NotFound($"Movie with id: {id} was not found!");

            return Ok(movie);
        }

        [HttpGet("GetByGenreId/{genreId}")]
        public async Task<IActionResult> GetByGenreIdAsync(int genreId)
        {
            var isValidGenre = await _genreRepo.IsValidGenreAsync(genreId);

            if (!isValidGenre)
                return BadRequest("Invalid movie genre Id");

            var movies = await _movieRepo.GetByGenreIdAsync(genreId);

            return Ok(movies);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateMovieDTO dto)
        {
            if (!_allowedExtensions.Contains(Path.GetExtension(dto.Poster.FileName.ToLower())))
                return BadRequest("Only 'png' or 'jpg' files are allowerd");

            if (dto.Poster.Length > _allowedMaxPosterSize)
                return BadRequest("Max allowed size for posters is 1MB");

            var isValidGenre = await _genreRepo.IsValidGenreAsync(dto.GenreId);

            if (!isValidGenre)
                return BadRequest("Invalid movie genre Id");

            using var dataStream = new MemoryStream();

            await dto.Poster.CopyToAsync(dataStream);

            var movie = new Movie
            {
                Title = dto.Title,
                Storyline = dto.Storyline,
                Year = dto.Year,
                Rate = dto.Rate,
                Poster = dataStream.ToArray(),
                GenreId = dto.GenreId
            };

            await _movieRepo.CreateAsync(movie);

            return Ok(movie);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateMovieDTO dto)
        {
            var movie = await _movieRepo.GetByIdAsync(id);

            if (movie == null)
                return NotFound($"Movie with id: {id} was not found!");

            if (dto.Poster != null)
            {
                if (!_allowedExtensions.Contains(Path.GetExtension(dto.Poster.FileName.ToLower())))
                    return BadRequest("Only 'png' or 'jpg' files are allowerd");

                if (dto.Poster.Length > _allowedMaxPosterSize)
                    return BadRequest("Max allowed size for posters is 1MB");

                var isValidGenre = await _genreRepo.IsValidGenreAsync(dto.GenreId);

                if (!isValidGenre)
                    return BadRequest("Invalid movie genre Id");

                using var dataStream = new MemoryStream();

                await dto.Poster.CopyToAsync(dataStream);

                movie.Poster = dataStream.ToArray();
            }

            movie.Title = dto.Title;
            movie.Storyline = dto.Storyline;
            movie.Year = dto.Year;
            movie.Rate = dto.Rate;
            movie.GenreId = dto.GenreId;

            _movieRepo.Update(movie);

            return Ok(movie);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepo.GetByIdAsync(id);

            if (movie == null)
                return NotFound($"Movie with id: {id} was not found!");

            _movieRepo.Delete(movie);

            return Ok(movie);
        }
    }
}

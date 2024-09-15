using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Repository.IRepository;

namespace MovieAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;        
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.movies.OrderBy(m => m.Title).Include(m => m.Genre).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> GetByGenreIdAsync(int genreId)
        {
            return await _context.movies.Include(m => m.Genre).Where(m => m.GenreId == genreId).ToListAsync();
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await _context.movies.AddAsync(movie);
            _context.SaveChanges();

            return movie;
        }

        public Movie Update(Movie movie)
        {
            _context.movies.Update(movie);
            _context.SaveChanges();

            return movie;
        }

        public Movie Delete(Movie movie)
        {
            _context.movies.Remove(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}

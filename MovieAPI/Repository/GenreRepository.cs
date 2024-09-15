using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Repository.IRepository;

namespace MovieAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.genres.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.genres.OrderBy(x => x.Title).ToListAsync();
        }
        public async Task<Genre> CreateAsync(Genre genre)
        {
            await _context.genres.AddAsync(genre);
            _context.SaveChanges();

            return genre;
        }
        public Genre Update(Genre genre)
        {
            _context.genres.Update(genre);
            _context.SaveChanges();

            return genre;
        }
        public Genre Delete(Genre genre)
        {
            _context.genres.Remove(genre);
            _context.SaveChanges();

            return genre;
        }

        public async Task<bool> IsValidGenreAsync(int id)
        {
            return await _context.genres.AnyAsync(g => g.Id == id);
        }
    }
}

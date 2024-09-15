using MovieAPI.Models;

namespace MovieAPI.Repository.IRepository
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> CreateAsync(Genre genre);
        Genre Update(Genre genre);
        Genre Delete(Genre genre);
        Task<bool> IsValidGenreAsync(int id);
    }
}

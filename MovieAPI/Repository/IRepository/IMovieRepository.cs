using MovieAPI.Models;

namespace MovieAPI.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<List<Movie>> GetByGenreIdAsync(int genreId);
        Task<Movie> CreateAsync(Movie movie);
        Movie Update(Movie movie);
        Movie Delete(Movie movie);
    }
}

namespace MovieAPI.DTOs
{
    public class UpdateMovieDTO : MovieBaseDTO
    {
        public IFormFile? Poster { get; set; }
    }
}

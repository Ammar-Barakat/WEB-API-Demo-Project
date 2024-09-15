namespace MovieAPI.DTOs
{
    public class CreateMovieDTO : MovieBaseDTO
    {
        public IFormFile Poster { get; set; }
    }
}

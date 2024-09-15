using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class MovieBaseDTO
    {
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Storyline { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public int GenreId { get; set; }
    }
}

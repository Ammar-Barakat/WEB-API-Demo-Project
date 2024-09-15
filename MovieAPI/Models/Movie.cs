using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Storyline { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public byte[] Poster { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

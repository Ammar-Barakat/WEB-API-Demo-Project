using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class GenreDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
    }
}

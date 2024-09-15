using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
    }
}

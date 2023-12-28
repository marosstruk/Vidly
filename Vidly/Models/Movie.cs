namespace Vidly.Models
{
    public class Movie
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required DateOnly DateAdded { get; set; }
        public required int NumberInStock { get; set; }
        public required Genre Genre { get; set; }
        public required short GenreId { get; set; }
    }
}

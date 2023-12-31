namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public DateOnly DateAdded { get; set; }
        public required int NumberInStock { get; set; }
        public required short GenreId { get; set; }
    }
}

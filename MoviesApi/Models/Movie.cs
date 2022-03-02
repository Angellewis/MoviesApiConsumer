namespace MoviesApi.Models
{
    public class Movie
    {
        public int page { get; set; }
        public object results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}

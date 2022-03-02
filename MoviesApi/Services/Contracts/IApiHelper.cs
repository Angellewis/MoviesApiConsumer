using MoviesApi.Models;
using System.Threading.Tasks;

namespace MoviesApi.Services.Contracts
{
    public interface IApiHelper
    {
        public Task<Movie> GetMovies();
        public Task<MovieDetail> GetMovieById(int id);
    }
}

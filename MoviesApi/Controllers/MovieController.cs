using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services.Contracts;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class MovieController : Controller
    {
        private readonly IApiHelper _apiHelper;
        public MovieController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("GetMovies")]
        public async Task<Movie> GetMovies()
        {
            return await _apiHelper.GetMovies();
        }

        [HttpGet("GetMovieDetails/{id}")]
        public async Task<MovieDetail> GetMovieById([FromRoute] int id)
        {
            return await _apiHelper.GetMovieById(id);
        }
    }
}

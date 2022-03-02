using MoviesApi.Models;
using MoviesApi.Services.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesApi.Services
{
    public class ApiHelper : IApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();
        public ApiHelper()
        {
            //Adding header to get Json data.
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Movie> GetMovies()
        {
            //Get Request from API
            using (HttpResponseMessage response = await ApiClient.GetAsync("https://api.themoviedb.org/3/movie/top_rated?api_key=bf091621962bdf5c30339e874a2a0c1a&language=en-US&page=1"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Movie movie = await JsonSerializer.DeserializeAsync<Movie>(await response.Content.ReadAsStreamAsync());

                    return movie;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<MovieDetail> GetMovieById(int id)
        {
            //Get Request from API, especifying the pokemon name
            using (HttpResponseMessage response = await ApiClient.GetAsync($"https://api.themoviedb.org/3/movie/{ id }?api_key=bf091621962bdf5c30339e874a2a0c1a&language=en-US"))
            {
                if (response.IsSuccessStatusCode)
                {
                    MovieDetail movieDetails = await JsonSerializer.DeserializeAsync<MovieDetail>(await response.Content.ReadAsStreamAsync());

                    return movieDetails;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

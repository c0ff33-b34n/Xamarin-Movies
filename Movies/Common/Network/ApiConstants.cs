using System;
using System.Collections.Generic;
using System.Text;

namespace Movies
{
    public static class ApiConstants
    {
        public static string GetMoviesUri(string searchTerm)
        {
            return $"https://www.omdbapi.com/?apikey=98389684&s={searchTerm}&page=1";
        }

        public static string GetMovieById(string imdbId)
        {
            return $"https://www.omdbapi.com/?apikey=98389684&i={imdbId}&plot=full";
        }
    }
}

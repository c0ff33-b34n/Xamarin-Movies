using System;
using System.Collections.Generic;
using System.Text;

namespace Movies
{
    public class BaseMovieInformation
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class ListOfMovies
    {
        public List<BaseMovieInformation> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}

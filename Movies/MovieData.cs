using System;
using System.Collections.Generic;
using System.Text;

namespace Movies
{
    public class MovieData
    {
        public MovieData(string title, string imageUrl)
        {
            Title = title;
            ImageUrl = imageUrl;
        }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}

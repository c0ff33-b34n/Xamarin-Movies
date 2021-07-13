
namespace Movies
{
    public class MovieData
    {
        public MovieData(string title, string imageUrl, string year, string imdbID)
        {
            Title = title;
            ImageUrl = imageUrl;
            Year = year;
            ImdbID = imdbID;
        }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
    }
}

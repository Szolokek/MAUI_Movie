
namespace Movie123.Model.Search
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string media_type { get; set; }
        public List<int> genre_ids { get; set; }
        public double popularity { get; set; }
        public string release_date { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public string first_air_date { get; set; }
        public List<string> origin_country { get; set; }
        public string imagesrc => "https://image.tmdb.org/t/p/w94_and_h141_bestv2" + poster_path;

        public bool visibilityTitle { get 
            {
                return title != null;
            }
            
        }
        public bool visibilityName
        {
            get
            {
                return name != null;
            }
        }
        public bool visibilityVoteAvarage { get 
        {
            return media_type != "person";
        }
            
        }
        
    }
}

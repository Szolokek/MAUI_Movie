using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.Model.Person
{
    public class Cast_Person
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }
        public string media_type { get; set; }
        public string imagesrc => "https://image.tmdb.org/t/p/w150_and_h225_bestv2" + poster_path;
    }

    public class Crew_Person
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string credit_id { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string media_type { get; set; }
    }

    public class PersonCombinedCredits
    {
        public List<Cast_Person> cast { get; set; }
        public List<Crew_Person> crew { get; set; }
        public int id { get; set; }
    }
}

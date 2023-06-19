using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.Model.Person
{
    public class PersonDetails
    {
        public bool adult { get; set; }
        public List<string> also_known_as { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public int gender { get; set; }
        public object homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public double popularity { get; set; }
        public string profile_path { get; set; }
        public string imgsrc => "https://image.tmdb.org/t/p/w300_and_h450_bestv2" + profile_path;
        public string imgsrcsmall => "https://image.tmdb.org/t/p/w138_and_h175_face" + profile_path;
        public string gender_string {
            get
            {
                if (gender == 1) return "Female";
                else return "Male";
                
            }
            set 
            { 
                gender_string = value;
            }
        }
    }
}

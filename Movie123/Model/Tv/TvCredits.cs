using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.Model.Tv
{
    public class TvCast
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public double popularity { get; set; }
        public string profile_path { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }
        public string imagesrc => "https://image.tmdb.org/t/p/w138_and_h175_face" + profile_path;
    }

    public class TvCredits
    {
        public List<TvCast> cast { get; set; }
        public List<object> crew { get; set; }
        public int id { get; set; }
    }
}

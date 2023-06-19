using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie123.Model.Search
{
    public class ResultPage
    {
        public int page { get; set; }
        public List<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public bool visibilityNextPrev
        {
            get
            {
                return results != null;
            }

        }
    }
}

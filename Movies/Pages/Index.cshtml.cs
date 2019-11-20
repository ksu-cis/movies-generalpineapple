using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        public List<Movie> Movies;


        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> rating { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMBD  { get; set; }

        [BindProperty]
        public float? maxIMBD { get; set; }


    public void OnGet()
        {
            Movies = MovieDatabase.All;
        }


        public void OnPost()
        {
            Movies = MovieDatabase.All;
            if(search != null)
                Movies = MovieDatabase.Search(Movies, search);
            if (rating.Count != 0)
                Movies = MovieDatabase.FilterByMPAA(Movies, rating);
            if (minIMBD != null)
                Movies = MovieDatabase.FilterByMinIMBD(Movies, (float)minIMBD);
            if (maxIMBD != null)
                Movies = MovieDatabase.FilterByMaxIMBD(Movies, (float)maxIMBD);
        }
    }
}

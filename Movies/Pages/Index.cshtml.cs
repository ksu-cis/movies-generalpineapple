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
        public MovieDatabase MovieDatabase = new MovieDatabase();

        public List<Movie> Movies;

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost(string search, string[] rating)
        {
            if(search != null)
                Movies = MovieDatabase.SearchAndFilter(search, rating);

        }
    }
}

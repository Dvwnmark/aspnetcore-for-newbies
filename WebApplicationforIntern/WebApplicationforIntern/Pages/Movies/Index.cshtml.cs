using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationforIntern.Data;
using WebApplicationforIntern.Models;

namespace WebApplicationforIntern.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationforIntern.Data.WebApplicationforInternContext _context;

        public IndexModel(WebApplicationforIntern.Data.WebApplicationforInternContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        public SelectList Genres;
        public string MovieGenre { get; set; }

        /* public async Task OnGetAsync()
         {
             Movie = await _context.Movie.ToListAsync();
         }*/

        /* public async Task OnGetAsync(string searchString)
         {
             var movies = from m in _context.Movie
                          select m;

             if (!String.IsNullOrEmpty(searchString))
             {
                 movies = movies.Where(s => s.Title.Contains(searchString));
             }

             Movie = await movies.ToListAsync();
         }*/
        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

    }

}

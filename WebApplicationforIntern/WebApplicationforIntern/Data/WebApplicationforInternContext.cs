using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationforIntern.Models;

namespace WebApplicationforIntern.Data
{
    public class WebApplicationforInternContext : DbContext
    {
        public WebApplicationforInternContext (DbContextOptions<WebApplicationforInternContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationforIntern.Models.Movie> Movie { get; set; } = default!;
    }
}

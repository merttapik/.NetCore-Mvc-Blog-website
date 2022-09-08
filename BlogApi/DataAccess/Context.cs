using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PA2B818;Database=BlogApiDb;Trusted_Connection=true");
        }
        public DbSet<BlogWebSiteRating> BlogWebSiteRatings { get; set; }
    }
}

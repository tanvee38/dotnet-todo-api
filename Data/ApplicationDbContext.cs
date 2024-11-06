using Microsoft.EntityFrameworkCore;
using RestApi.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RestApi.Models.Recipe> Recipe { get; set; } = default!;
    }

using Microsoft.EntityFrameworkCore;
using RestApi.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RestApi.Models.Todo> Todos { get; set; } = default!;
    }

using AspNetCorePlayground.Data.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCorePlayground.Data
{
    public class PlaygroundContext : IdentityDbContext
    {
        public PlaygroundContext(DbContextOptions<PlaygroundContext> options)
            : base(options)
        {
        }

        public DbSet<Installation> Installations { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Platform> platforms { get; set; }
    }
}
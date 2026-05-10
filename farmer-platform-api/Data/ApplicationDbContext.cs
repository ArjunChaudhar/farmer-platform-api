using farmer_platform_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmerPlatform.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
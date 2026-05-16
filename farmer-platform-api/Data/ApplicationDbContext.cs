using farmer_platform_api.Entities;
using farmer_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmerPlatform.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        public DbSet<Crop> Crops { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
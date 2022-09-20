using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuslimApp.Models;
using System.Diagnostics.Metrics;

namespace MuslimApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);
        }
        public DbSet<mosque> mosques { get; set; }
        public DbSet<member> members { get; set; }
        public DbSet<Donation> donations { get; set; }
    }
}
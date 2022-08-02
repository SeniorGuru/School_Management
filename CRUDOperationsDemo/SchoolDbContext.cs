using CRUDOperationsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperationsDemo
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> subjects { get; set; }
    }
}

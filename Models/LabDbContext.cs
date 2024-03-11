using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public class LabDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public LabDbContext() { }
        public LabDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1T6LFVE\\SQLEXPRESS;Database=Lab;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

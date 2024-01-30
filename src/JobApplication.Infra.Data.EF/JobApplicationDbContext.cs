using JobApplication.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Infra.Data.EF
{
    public class JobApplicationDbContext : DbContext
    {
        public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connString = "Host=db;Username=postgres;Password=postgres;Database=JobApplicationTracker";

        //    optionsBuilder.UseNpgsql(connString);
        //}

    }
}

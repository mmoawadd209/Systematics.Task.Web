using Microsoft.EntityFrameworkCore;

namespace Systematics.Task.Web.Models
{
    public class SystematicsDbContext : DbContext
    {

        public SystematicsDbContext(DbContextOptions<SystematicsDbContext> options)
         : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(x=>x.UserName);
            modelBuilder.Entity<User>().Property(x=>x.UserName).HasColumnName("User_Name");

            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Project>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<Project>().Property(x => x.Name).HasColumnName("Project_Name");
            modelBuilder.Entity<Project>().Property(x => x.Progress).HasColumnName("Project_Progress");
            modelBuilder.Entity<Project>().Property(x => x.StatusId).HasColumnName("Status_ID");


            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Status>().Property(x=>x.Id).HasColumnName("ID");
            modelBuilder.Entity<Status>().Property(x=>x.ProjectStatus).HasColumnName("Status");
            modelBuilder.Entity<Status>().HasData(new Status { Id = 1 , ProjectStatus = "Success"}, new Status { Id = 2 , ProjectStatus = "Failed" });

        }
    }
}

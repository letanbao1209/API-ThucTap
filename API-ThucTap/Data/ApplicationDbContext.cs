using API_ThucTap.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ThucTap.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<VisitSchedule> VisitSchedules { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User <-> Role
            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Article <-> User (Author)
            modelBuilder.Entity<Article>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification <-> User (Recipient)
            modelBuilder.Entity<Notification>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Survey <-> User (Creator)
            modelBuilder.Entity<Survey>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Survey <-> Question
            modelBuilder.Entity<Question>()
                .HasOne<Survey>()
                .WithMany()
                .HasForeignKey(q => q.SurveyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job <-> User (AssignedUser)
            modelBuilder.Entity<Job>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job <-> VisitSchedule
            modelBuilder.Entity<Job>()
                .HasOne<VisitSchedule>()
                .WithMany()
                .HasForeignKey(t => t.VisitScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            // VisitSchedule <-> Area
            modelBuilder.Entity<VisitSchedule>()
                .HasOne<Area>()
                .WithMany()
                .HasForeignKey(v => v.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            // VisitSchedule <-> Distributor
            modelBuilder.Entity<VisitSchedule>()
                .HasOne<Distributor>()
                .WithMany()
                .HasForeignKey(v => v.DistributorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Area <-> Distributor
            modelBuilder.Entity<Distributor>()
                .HasOne<Area>()
                .WithMany()
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

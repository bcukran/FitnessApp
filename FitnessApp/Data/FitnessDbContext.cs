using FitnessApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class FitnessDbContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enroll> Enrolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("Turkish_CI_AS");

            modelBuilder.Entity<Course>(eb =>
            {
                eb.ToTable(nameof(Course));

                eb.HasKey(e => e.Id);

                eb.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                eb.Property(e => e.Description)
                    .HasMaxLength(250);

                eb.Property(e => e.Duration)
                    .HasDefaultValue(5)
                    .IsRequired();
            });

            modelBuilder.Entity<Enroll>(eb =>
            {
                eb.ToTable(nameof(Enroll));
               
                eb.HasKey(e => e.Id);

                eb.HasOne(e => e.Course).WithMany(c => c.Enrolls)
                    .HasForeignKey(e => e.CourseId)
                    .HasConstraintName("FK_Enroll_Course");

                eb.HasOne(e => e.User).WithMany(c => c.Enrolls)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_Enroll_User");
            });

            // Use seed method here
            modelBuilder.Seed();
        }
    }
}

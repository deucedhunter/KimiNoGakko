using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KimiNoGakko.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithOne(e => e.Class);


            modelBuilder.Entity<Course>()
                .HasOne<Enrollment>(a => a.Enrollment)
                .WithOne(b => b.Course)
                .HasForeignKey<Enrollment>(b => b.CourseID);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => e.CourseID)
                .IsUnique(false);

        }

    }
}

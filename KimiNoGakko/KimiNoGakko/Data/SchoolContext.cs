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
        public DbSet<Presence> Presence { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Presence>().ToTable("Presence");

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

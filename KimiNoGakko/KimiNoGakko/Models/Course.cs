using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        [Key]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}

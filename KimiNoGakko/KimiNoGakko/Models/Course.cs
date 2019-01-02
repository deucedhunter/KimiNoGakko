namespace KimiNoGakko.Models
{
    public class Course
    {
        public int ID { get; set; }


        public string FullName { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        public Enrollment Enrollment { get; set; }


    }
}

namespace KimiNoGakko.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int ClassID { get; set; }
        public Class Class { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
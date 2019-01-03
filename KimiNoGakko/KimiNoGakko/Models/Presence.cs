using System;
using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Presence
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DataType(DataType.Time)]
        public DateTime Godzina { get; set; }

        public bool IsPresent { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        public int CourseID { get; set; }
        public Subject Course { get; set; }
    }
}

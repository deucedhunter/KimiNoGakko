using System.Collections.Generic;

namespace KimiNoGakko.Models
{
    public class Course
    {
        public int ID { get; set; }


        public string FullName { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public Enrollment Enrollment { get; set; }


        public IEnumerable<Presence> Presence { get; set; }
        public IEnumerable<Grade> Grades { get; set; }


    }
}

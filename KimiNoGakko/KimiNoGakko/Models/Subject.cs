using System.Collections.Generic;

namespace KimiNoGakko.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public bool IsImportant { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}

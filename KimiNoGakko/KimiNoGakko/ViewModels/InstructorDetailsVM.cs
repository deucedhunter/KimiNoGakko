using KimiNoGakko.Models;
using System.Collections.Generic;

namespace KimiNoGakko.ViewModels
{
    public class InstructorDetailsVM
    {
        public Instructor Instructor { get; set; }
        public List<Course> Courses { get; set; }
    }
}

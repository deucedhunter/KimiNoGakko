using KimiNoGakko.Models;
using System.Collections.Generic;

namespace KimiNoGakko.ViewModels
{
    public class ClassDetailsVM
    {
        public Class Class { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}

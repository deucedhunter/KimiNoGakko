using KimiNoGakko.Models;
using System.Collections.Generic;

namespace KimiNoGakko.ViewModels
{
    public class EmployeeDetailsVM
    {
        public Employee Employee { get; set; }
        public List<Course> Courses { get; set; }
    }
}

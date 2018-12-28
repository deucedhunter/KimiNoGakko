using KimiNoGakko.Models;
using System.Collections.Generic;

namespace KimiNoGakko.ViewModels
{
    public class StudentClassVM
    {
        public Student Student { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Student : Person
    {
        [Display(Name = "Numer opiekuna")]
        public string GudrdianPhoneNumber { get; set; }
    }
}

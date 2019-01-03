using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Student : Person
    {
        [Display(Name = "Numer opiekuna")]
        public string GudrdianPhoneNumber { get; set; }

        public int ClassID { get; set; }
        public Class Class { get; set; }


        public IEnumerable<Presence> Presence { get; set; }


    }
}
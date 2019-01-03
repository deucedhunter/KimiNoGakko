using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimiNoGakko.Models
{
    public class Presence
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DataType(DataType.Time)]
        public DateTime Godzina { get; set; }

        [Display(Name = "Obecność")]
        public bool IsPresent { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }


        [ForeignKey("EmployeeID")]
        public int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }


        [ForeignKey("CourseID")]
        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}

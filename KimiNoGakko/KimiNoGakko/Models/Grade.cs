using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KimiNoGakko.Models
{
    public class Grade
    {
        public int ID { get; set; }

        [Range(2.0, 5.0), RegularExpression(@"^\d+\.\d{0,1}$")]
        public decimal Value { get; set; }

        [ForeignKey("StudentID")]
        public int? StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("EmployeeID")]
        public int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("CourseID")]
        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }
    }

}

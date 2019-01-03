using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Employee : Person
    {
        [DataType(DataType.Date), Display(Name = "Data Zatrudnienia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime HireDate { get; set; }

        public IEnumerable<Presence> Presence { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}

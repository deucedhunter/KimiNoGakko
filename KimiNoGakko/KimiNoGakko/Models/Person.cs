using System;
using System.ComponentModel.DataAnnotations;

namespace KimiNoGakko.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required, StringLength(60), Display(Name = "Imiona")]
        public string FirstMidName { get; set; }

        [Required, StringLength(30), Display(Name = "Naziwsko")]
        public string LastName { get; set; }

        [DataType(DataType.Date), Display(Name = "Data Urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Pesel { get; set; }

        [Display(Name = "Imię i Nazwisko")]
        public string FullName
        {
            get
            {
                return FirstMidName + " " + LastName;
            }
        }
    }
}

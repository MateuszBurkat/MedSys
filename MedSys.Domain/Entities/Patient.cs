using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MedSys.Domain.Entities
{
    public class Patient
    {
        [HiddenInput(DisplayValue =false)]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwisko pacjenta")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Proszę podać imię pacjenta")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Proszę podać pesel pacjenta")]
        public string Pesel { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [DataType(DataType.MultilineText), Display(Name= "Opis")]
        public string Description { get; set; }

        [Display(Name = "Badania medyczne")]
        public string MedicalTestResult { get; set; }
       
      
    }
}

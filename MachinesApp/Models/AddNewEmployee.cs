using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace MachinesApp.Models
{
    public class AddNewEmployee
    {
        [Required(ErrorMessage = "Brak wartości pola Imię")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Nazwisko")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Dział")]
        public string Dept { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Stanowisko")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Adres email")]
        public string Email_Adress { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Numer telefonu")]
        public string Phone_Number { get; set; }
      
    }
}
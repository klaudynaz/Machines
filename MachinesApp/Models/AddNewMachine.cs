using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachinesApp.Models.DB
{
    public class AddNewMachine
    {
        [Required(ErrorMessage = "Brak wartości pola Id")]
        public int Id_machine { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Numer seryjny")]
        public int Serial_number { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Producent")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Model maszyny")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Wymiary")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Opis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Brak wartości pola Waga")]
        public int Weight { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachinesApp.Models.DB
{
    public class Hire
    {
        [Key, Required]
        public int Id_hire { get; set; }
        [Required]
        public DateTime Date_from { get; set; }
        [Required]
        public DateTime To_Date { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
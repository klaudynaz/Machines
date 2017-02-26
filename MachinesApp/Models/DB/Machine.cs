using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachinesApp.Models.DB
{
    public class Machine
    {
        [Key, Required]
        public int Id_machine { get; set; }
        [Required]
        public int Serial_number { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Weight { get; set; }

        public virtual List <Hire> Hires { get; set; }
    }
}
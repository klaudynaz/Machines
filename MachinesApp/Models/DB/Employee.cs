using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachinesApp.Models.DB
{
    public class Employee
    {
        [Key, Required]
        public int Id_employee { get; set; }
        [Required]
        public string First_Name { get; set;}
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Dept { get; set; }
        [Required]
        public string Position { get; set;  }
        [Required]
        public string Email_Adress { get; set; }
        [Required]
        public string Phone_Number { get; set; }


        public virtual List <Hire> Hires { get; set; }


    }
}
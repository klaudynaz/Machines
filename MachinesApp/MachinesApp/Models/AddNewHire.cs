using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MachinesApp.Models.DB;

namespace MachinesApp.Models
{
    public class AddNewHire
    {
        public int Id_machine { get; set; }
        public int Id_employee { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Machine> Machines { get; set; }

    }
}
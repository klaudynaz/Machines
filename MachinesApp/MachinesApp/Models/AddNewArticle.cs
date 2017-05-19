using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachinesApp.Models.DB
{
    public class AddNewArticle
    {
        [Required(ErrorMessage = "Brakuje wartości pola Id")]
        public int Id_article { get; set; }
        [Required(ErrorMessage = "Brakuje wartości Data")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Brakuje wartości pola Tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Brakuje treści artykułu")]
        public string Text { get; set; }
    }
}
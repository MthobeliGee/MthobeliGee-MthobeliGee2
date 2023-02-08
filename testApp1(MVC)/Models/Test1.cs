using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testApp1_MVC_.Models
{
    public class Test1
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string excelFile { get; set; }
        public string extection { get; set; }
    }
}
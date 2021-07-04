using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace ExamApp.Models
{
    public class Exam
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public Question Question1 { get; set; }
        public Question Question2 { get; set; }
        public Question Question3 { get; set; }
        public Question Question4 { get; set; }
    }
}

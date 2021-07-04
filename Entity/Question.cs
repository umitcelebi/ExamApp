using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        public string QuestionsName { get; set; }
        [Required]
        public string Options1 { get; set; }
        [Required]
        public string Options2 { get; set; }
        [Required]
        public string Options3 { get; set; }
        [Required]
        public string Options4 { get; set; }
        [Required]
        public int Solution { get; set; }
    }
}

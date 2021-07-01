using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionsName { get; set; }
        public string Options1 { get; set; }
        public string Options2 { get; set; }
        public string Options3 { get; set; }
        public string Options4 { get; set; }
        public int Solution { get; set; }
    }
}

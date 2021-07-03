using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;

namespace Entity
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Topic Topic { get; set; }
        public int TopicId { get; set; }

        public int Score { get; set; }
    }
}

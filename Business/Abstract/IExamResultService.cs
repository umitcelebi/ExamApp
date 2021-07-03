using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Abstract
{
    public interface IExamResultService
    {
        ExamResult GetById(int id);
        List<ExamResult> GetAll();
        void Add(ExamResult entity);
        
    }
}

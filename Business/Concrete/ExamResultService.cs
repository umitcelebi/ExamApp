using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity;

namespace Business.Concrete
{
    public class ExamResultService:IExamResultService
    {
        private IExamResultDal _examResultDal;

        public ExamResultService(IExamResultDal examResultDal)
        {
            _examResultDal = examResultDal;
        }

        public ExamResult GetById(int id)
        {
            return _examResultDal.Get(r => r.ExamResultId == id);
        }

        public List<ExamResult> GetAll()
        {
            return _examResultDal.GetAll();
        }

        public void Add(ExamResult entity)
        {
            _examResultDal.Add(entity);
        }
    }
}

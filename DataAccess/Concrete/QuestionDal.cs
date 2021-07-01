using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity;

namespace DataAccess.Concrete
{
    public class QuestionDal:GenericRepository<Question,ApplicationContext>,IQuestionDal
    {
    }
}

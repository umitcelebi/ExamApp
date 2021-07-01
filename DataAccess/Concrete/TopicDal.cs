using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TopicDal:GenericRepository<Topic,ApplicationContext>,ITopicDal
    {
        public Topic GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Topics
                    .Include(a => a.Questions)
                    .FirstOrDefault(b => b.TopicId == id);
            }
        }
    }
}

using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITopicService
    {
        Topic GetById(int id);
        List<Topic> GetAll();
        void Add(Topic topic);
        void Delete(Topic topic);
        void Update(Topic topic);
    }
}

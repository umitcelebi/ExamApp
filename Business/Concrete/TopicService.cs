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
    public class TopicService:ITopicService
    {
        private ITopicDal _topicDal;

        public TopicService(ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }

        public Topic GetById(int id)
        {
            return _topicDal.GetById(id);
        }

        public List<Topic> GetAll()
        {
            return _topicDal.GetAll();
        }

        public void Add(Topic topic)
        {
            topic.CreateTime=DateTime.Now;
            _topicDal.Add(topic);
        }

        public void Delete(Topic topic)
        {
            _topicDal.Delete(topic);
        }

        public void Update(Topic topic)
        {
            _topicDal.Update(topic);
        }
    }
}

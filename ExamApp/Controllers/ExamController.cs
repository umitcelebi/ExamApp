using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entity;
using ExamApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Controllers
{
    public class ExamController : Controller
    {
        private ITopicService _topicService;

        public ExamController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult Index()
        {
            return View(_topicService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Topics = new SelectList(DataExtraction.getTopic(), "Body", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult CreateExam(Exam exam)
        {

            var questions =new List<Question>()
            {
                exam.Question1,
                exam.Question2,
                exam.Question3,
                exam.Question4
            };
            var topic = new Topic()
            {
                Title = exam.Title,
                Body = exam.Body,
                Questions = questions
            };

            _topicService.Add(topic);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var exam = _topicService.GetById(id);
            if (exam != null)
            {
                _topicService.Delete(exam);
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DoExam(int id)
        {

            return View(_topicService.GetById(id));
        }

        [HttpPost]
        public IActionResult DoExam()
        {
            return RedirectToAction("Index");
        }
    }
}

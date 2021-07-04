using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entity;
using Entity.Identity;
using ExamApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private ITopicService _topicService;
        private UserManager<ApplicationUser> _userManager;
        private IExamResultService _examResultService;
        public ExamController(ITopicService topicService, UserManager<ApplicationUser> userManager, IExamResultService examResultService)
        {
            _topicService = topicService;
            _userManager = userManager;
            _examResultService = examResultService;
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
            if (ModelState.IsValid)
            {
                var questions = new List<Question>()
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

            throw new Exception();
            return View("Create", exam);
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
        public async Task<IActionResult> DoExam(string username, int topicId, int score)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = new ExamResult()
            {
                UserId = user.Id,
                TopicId = topicId,
                Score = score
            };

            _examResultService.Add(result);

            return RedirectToAction("Index");
        }
    }
}

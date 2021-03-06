using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using N01419541_JatinderSingh_Assignment2_3.DAL;
using N01419541_JatinderSingh_Assignment2_3.Models;

namespace N01419541_JatinderSingh_Assignment2_3.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private QuestionContext db = new QuestionContext();
        Boolean flag = true;

        // Display Questions List
        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Category);
            return View(questions.ToList());
        }

        // Shows Question details from Questions List and its other functionalities
        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);

            if (flag)
            {
                int viewcount = question.Views;
                question.Views = viewcount + 1;
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                flag = false;
            }

            if (question == null)
            {
                return HttpNotFound();
            }

            var reviewList = new List<Review>();
            reviewList = db.Reviews.Where(x => x.QuestionId.Equals(question.QuestionId)).ToList();
            int counter = reviewList.Count();
            ViewBag.Count = counter;

            var answerList = new List<Answer>();
            answerList = db.Answers.Where(x => x.QuestionId.Equals(question.QuestionId)).ToList();
            int counterAns = answerList.Count();
            ViewBag.CountAnswer = counterAns;

            return View(question);
        }

        // Create or Ask a new Question
        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,QuestionName,QuestionDateAndTime,CategoryId")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.QuestionDateAndTime = DateTime.Now;
                question.Name = System.Web.HttpContext.Current.User.Identity.GetUserName();
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", question.CategoryId);
            return View(question);
        }

        // Edit an existing question
        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", question.CategoryId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,QuestionName,QuestionDateAndTime,CategoryId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                question.QuestionDateAndTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", question.CategoryId);
            return View(question);
        }

        // Answer a question in Question details
        public ActionResult AddAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            ViewBag.QuestionId = question.QuestionId;
            ViewBag.Question = question.QuestionName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer([Bind(Include = "AnswerId,QuestionId,AnswerText,AnswerDateAndTime")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                answer.AnswerDateAndTime = DateTime.Now;
                answer.Name = System.Web.HttpContext.Current.User.Identity.GetUserName();
                db.Answers.Add(answer);
                db.SaveChanges();

                return RedirectToAction("ViewAnswers", 
                    new RouteValueDictionary
                        (
                           new { controller = "Questions", 
                                 action = "ViewAnswers", 
                                 Id = answer.QuestionId }
                         ));                
            }

            return View(answer);
        }

        // Display the answers to a question in Question details
        public ActionResult ViewAnswers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);

            var ansList = new List<Answer>();
            if (question != null)
            {
                ViewBag.QuestionName = question.QuestionName;
                using (db)
                {
                    ansList = db.Answers.Where(x => x.QuestionId.Equals(question.QuestionId)).ToList();
                }
            }
            
            ViewBag.QuestionId = question.QuestionId;
            if (ansList != null)
            {
                return View(ansList);
            }
            return View();
        }

        //Display the details of each answer
        public ActionResult DetailAnswers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //Edit an existing answer
        public ActionResult EditAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }

            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnswer([Bind(Include = "AnswerId,QuestionId,AnswerText,AnswerDateAndTime")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                answer.AnswerDateAndTime = DateTime.Now;
                db.SaveChanges();
                
                return RedirectToAction("ViewAnswers", 
                    new RouteValueDictionary
                    (
                        new { controller = "Questions", 
                              action = "ViewAnswers", 
                              Id = answer.QuestionId }
                     ));
            }

            return View(answer);
        }

        //Vote a question
        public ActionResult AddVote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            ViewBag.QuestionId = question.QuestionId;
            ViewBag.Question = question.QuestionName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddVote([Bind(Include = "Id,Votes,QuestionId")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.Vote = true;
                db.Reviews.Add(review);
                db.SaveChanges();

                return RedirectToAction("Details", 
                    new RouteValueDictionary
                    (
                        new { controller = "Questions", 
                              action = "Details", 
                              Id = review.QuestionId }
                    ));                
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

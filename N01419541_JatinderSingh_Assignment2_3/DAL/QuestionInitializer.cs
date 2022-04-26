using N01419541_JatinderSingh_Assignment2_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N01419541_JatinderSingh_Assignment2_3.DAL
{
    public class QuestionInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<QuestionContext>
    {
        protected override void Seed(QuestionContext context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="HTML"},
                new Category{CategoryId=2, CategoryName="CSS"},
                new Category{CategoryId=3, CategoryName="JavaScript" }
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var questions = new List<Question>
            {
                new Question{QuestionId=1, Name="emily@gmail.com", Views=0, QuestionName="document.getElementById() is not working?", QuestionDateAndTime=DateTime.Parse("2022-04-10 11:00:00"), CategoryId=3},
                new Question{QuestionId=2, Name="david@gmail.com", Views=0, QuestionName="How to set background image in CSS?", QuestionDateAndTime=DateTime.Parse("2022-04-12 10:00:00"), CategoryId=2},
                new Question{QuestionId=3, Name="johndoe@gmail.com", Views=0, QuestionName="How to display icon the browser title bar using HTML?", QuestionDateAndTime=DateTime.Parse("2022-04-11 10:15:00"), CategoryId=1}
            };

            questions.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();

            var answers = new List<Answer>
            {
                new Answer{AnswerId=1, QuestionId=1, AnswerText="Set Id", Name="johndoe@gmail.com", AnswerDateAndTime=DateTime.Parse("2022-04-10 16:00:00")}
            };

            answers.ForEach(s => context.Answers.Add(s));
            context.SaveChanges();
        }
    }
}
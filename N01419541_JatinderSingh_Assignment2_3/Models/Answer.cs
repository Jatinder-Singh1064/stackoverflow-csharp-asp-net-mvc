using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace N01419541_JatinderSingh_Assignment2_3.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Answer ID")]
        public int AnswerId { get; set; }

        [DisplayName("Question ID")]
        public int QuestionId { get; set; }

        [DisplayName("Answer")]
        public string AnswerText { get; set; }

        [DisplayName("Last Updated")]
        public DateTime AnswerDateAndTime { get; set; }

        [DisplayName("Posted By")]
        public String Name { get; set; }

        public virtual Question Question { get; set; }
    }
}
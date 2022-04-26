using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace N01419541_JatinderSingh_Assignment2_3.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Question ID")]
        public int QuestionId { get; set; }

        [DisplayName("Question")]
        public string QuestionName { get; set; }

        [DisplayName("Views")]
        public int Views { get; set; }

        [DisplayName("Last Updated")]
        public DateTime QuestionDateAndTime { get; set; }

        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Posted By")]
        public String Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
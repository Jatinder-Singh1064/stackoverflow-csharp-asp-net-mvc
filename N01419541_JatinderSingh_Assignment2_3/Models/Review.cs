using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace N01419541_JatinderSingh_Assignment2_3.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DisplayName("Votes")]
        public bool Vote { get; set; }

        [DisplayName("Question ID")]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
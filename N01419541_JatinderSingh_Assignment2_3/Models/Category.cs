using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace N01419541_JatinderSingh_Assignment2_3.Models
{
    public class Category
    {
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
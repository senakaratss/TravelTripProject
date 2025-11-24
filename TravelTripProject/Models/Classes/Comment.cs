using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
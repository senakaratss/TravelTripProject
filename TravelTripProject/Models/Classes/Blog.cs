using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string BlogImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
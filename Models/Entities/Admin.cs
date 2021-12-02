using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Entities
{
    public class Admin
    {
        [Key] 
        public int Id { get; set; }

        public string User { get; set; }
        public string Password { get; set; }
        
    }
}
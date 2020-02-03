using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDIler.Data.Models.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        
        public string SurName { get; set; }

        public string Bio { get; set; }
        
        public string Position { get; set; }
        
        public int Year { get; set; }
    }
}

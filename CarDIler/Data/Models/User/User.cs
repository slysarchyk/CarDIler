using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDIler.Data.Models.User
{
    public class User : IdentityUser
    {
        [Range(3,10)]
        public string Name { get; set; }
        
        [Range(3,10)]
        public string SurName { get; set; }

        [Range(1,100)]
        public string Bio { get; set; }
        
        [Range(1,10)]
        public string Position { get; set; }
        
        public int Year { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.Data.Models.Post
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [MinLength(10)]
        public string ShortDesc { get; set; }
        
        [Required]
        [Range(0, 60)]
        public string Desc { get; set; }
        
        [Required]
        public string Date { get; set; }
    }
}

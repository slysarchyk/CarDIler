using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.Data.Models
{
    public class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        [Required]
        public string Desc { get; set; }

        public string Date { get; set; }
        public string DateEdit { get; set; }
        public string AddedBy { get; set; }

        public string CoverPath { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.ViewModel
{
    public class AddPostViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string CoverPath { get; set; }
    }
}

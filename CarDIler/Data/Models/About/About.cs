using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.Data.Models.About
{
    public class About
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Info_1 { get; set; }
        public string Info_2 { get; set; }
        public string Info_3 { get; set; }
        public string Info_4 { get; set; }
    }
}

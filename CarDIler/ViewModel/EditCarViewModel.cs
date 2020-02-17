using CarDIler.Data.Models.Car;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.ViewModel
{
    public class EditCarViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sold { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }
 
        [Required]
        public double Engine { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Distance { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Vin { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double PriceNetto { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double PriceBrutto { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Profit { get; set; }

        [Required]
        public string Desc { get; set; }

        public string Date { get; set; }
        public string DateEdit { get; set; }
        public string AddByName { get; set; }
        public string AddBySurname { get; set; }
        public string AddByPhoneNumber { get; set; }
        public string AddByPosition { get; set; }
        public string CoverPath { get; set; }
    }
}

using CarDIler.Data.Models.Car;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.ViewModel
{
    public class AddCarViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public int BrandId { get; set; }
        public Category Category { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }

        public double Engine { get; set; }
        public int Distance { get; set; }
        public string Color { get; set; }
        public string Vin { get; set; }
        public double PriceNetto { get; set; }
        
        public string ICoverName { get; set; }
        public string Path { get; set; }
    }
}

using CarDIler.Data.Models.Car;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.ViewModel
{
    public class AddCarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sold { get; set; }

        public int BrandId { get; set; }

        public Category Category { get; set; }
        public Fuel Fuel { get; set; }

        public int Year { get; set; }
        public double Engine { get; set; }
        public int Distance { get; set; }
        public string Color { get; set; }
        public string Vin { get; set; }
        public double PriceNetto { get; set; }

        public double PriceBrutto { get; set; }
        public double Profit { get; set; }

        public string Desc { get; set; }

        public string Date { get; set; }
        public string DateEdit { get; set; }
        public string AddedBy { get; set; }
        public string CoverPath { get; set; }
    }
}

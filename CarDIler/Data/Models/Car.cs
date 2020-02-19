using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.Data.Models.Car
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Sold { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public Category Category { get; set; }
        public Fuel Fuel { get; set; }


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

        public virtual ICollection<CarImages> CarImages { get; set; }
        public Car()
        {
            CarImages = new List<CarImages>();
        }
    }
    public class CarImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Path { get; set; }
        
        public int CarId { get; set; }
        public Car Cars { get; set; }
    }


    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new List<Car>();
        }
    }

    public enum Category
    {
        Cabriolet = 1,
        City = 2,
        Coupe = 3,
        Luxury = 4,
        Minibus = 5,
        Sedan = 6,
        SUV = 7,
        Combi = 8,
        Van = 9,
        Hatchback = 10,
        Classic = 11,
        Campervan = 12
    }
    
    public enum Fuel
    {
        Gas = 1,
        Diesel = 2,
        Electric = 3,
        Hybrid = 4
    }
}

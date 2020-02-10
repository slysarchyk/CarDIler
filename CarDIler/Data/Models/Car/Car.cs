using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public int YearId { get; set; }
        public Year Year { get; set; }

        public int CatId { get; set; }
        public Category Category { get; set; }

        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }

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

        //AddByUser
        public string AddByName { get; set; }
        public string AddBySurname { get; set; }
        public string AddByPhoneNumber { get; set; }
        public string AddByPosition { get; set; }

        public string CoverPath { get; set; }

        public virtual ICollection<Galery> Galeries { get; set; }
        public Car()
        {
            Galeries = new List<Galery>();
        }
    }
    public class Galery
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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CatName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Category()
        {
            Cars = new List<Car>();
        }
    }
    public class Fuel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FuelName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Fuel()
        {
            Cars = new List<Car>();
        }
    }

    public class Year
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string YearName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Year()
        {
            Cars = new List<Car>();
        }
    }

}

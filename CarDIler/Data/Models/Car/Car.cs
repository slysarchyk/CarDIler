﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDIler.Data.Models.Car
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        public double Engine { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Distance { get; set; }

        public string Color { get; set; }
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


        public string Desc { get; set; }
        public string Date { get; set; }

        public string ICoverName { get; set; }
        public string Path { get; set; }
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
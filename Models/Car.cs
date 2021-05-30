using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkingMVC.Models
{
    public class Car
    {
        public int id { get; set; }

        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Display(Name = "Car Model")]
        public string CarModel { get; set; }



        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}

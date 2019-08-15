using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoleProject.Models
{
    public class Car
    {
        [Key]
        [Required]
        [Display(Name = "Car Number")]

        public String Car_Id { get; set; }
        [Required]
        [Display(Name = "Type of Car")]

        public string Type_Of_Car { get; set; }
        [Required]
        [Display(Name = "Car Brand")]

        public string Car_Brand { get; set; }
        [Required]
        [Display(Name = "CAr Model")]

        public string Car_Model { get; set; }
        [Required]
        [Display(Name = "Chassis number")]

        public int Chassis_No { get; set; }
        [Display(Name = "Date of book")]

        public Nullable<DateTime> Start_Book_Date { get; set; }
        [Display(Name = "Date of finish Book")]

        public Nullable<DateTime> End_Book_Date { get; set; }
        [Required]
        [Display(Name = "Price per day")]

        public double price_in_day { get; set; }
        public Nullable<double> price_Total { get; set; }
        [Display(Name = "Booked")]
        
        public bool Is_reseved { get; set; } 
        [ForeignKey("Car_no")]
        public Collection<Car_properties> Additional_properties { get; set; }
        public string photo_Car { get; set; }
        [NotMapped]
        public HttpPostedFileBase photo_path { get; set; }
        
        public Client CLIENT { get; set; }
       
        public Agince Agince_Of_Car { get; set; }

    }
}
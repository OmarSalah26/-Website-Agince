using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleProject.Models
{
    public class Car_properties
    {
        
        [Key]
        public int id { get; set; }
        [Required]
        public string proprity_Name { get; set; }
        public List<Car> Car { get; set; }
    }
}
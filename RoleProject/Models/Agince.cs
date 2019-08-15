using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace RoleProject.Models
{
    public class Agince
    {
        [Key]
        [Required]
        public String Agince_ID { get; set; }
        [Required]

        public string name { get; set; }

        private string Password_Agence;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string password { get { return Password_Agence; } set { Password_Agence = value; } }

        //[NotMapped]
        //[Display(Name = "Confirm Password")]
        //[Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        //[DataType(DataType.Password)]

        //public string confirm_Password { get; set; }

        // collection of phone for agence
        [Display(Name =  "Phone Number")]
       
        public string phone_number { get; set; }
   
        public string city { get; set; }
    
        public string street { get; set; }
        [Display(Name ="photo of Agince")]
        public string photo_Agince { get; set; }
        [NotMapped]
        public HttpPostedFileBase photo_path { get; set; }
        // Collection of cars in Agince 
        public Collection<Car> Collection_Of_Car { get; set; }
        public virtual ApplicationUser userAccount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoleProject.Models
{
    public delegate object Bookcar_delegate(int car_Num, DateTime start_Book_Date, DateTime end_Book_Date);
    public class Client
    {
        [Required]
        public string Name { get; set; }
        [Key]
        [Required]
        [Display(Name = "ID")]
        public String Client_ID { get; set; }
        private string Password_Client;
        [Required]
        [DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string password { get; set; }
        //[NotMapped]
        //[Display(Name = "Confirm Password")]
        //[Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        //[DataType(DataType.Password)]

        //public string confirm_Password { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone number")]

        public string phone_Number { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Street")]
        public string street { get; set; }

        [Display(Name = "Age")]
        public Nullable<int> age { get; set; }

        [Display(Name = "Licience Number")]

        public Nullable<int> number_of_licience { get; set; }
        [Display(Name = "Date of Licience expiry")]

        public Nullable<DateTime> date_of_licience_expiry { get; set; }
        public Collection<Car> Booked_Car { get; set; }
        public event Bookcar_delegate book_Car_Event;
    }
}
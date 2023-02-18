﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FlightBookingSystem.Models.Domain
{
    public class Registration
    {

        [Required]
        [StringLength(40)]
        public string FullName { get; set; }
        [Key]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        //Navigation property
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FlightBookingSystem.Models.Domain
{
    public class Checkin
    {
        [Column("CheckInId")]
        public int Check_Id { get; set; }
        [Required]
        [Display(Name = "Seatno.")]
        public int Seat_Allocation { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Booking_id { get; set; }
        [ForeignKey("Booking_id")]
        public virtual Booking Booking { get; set; }
    }
}

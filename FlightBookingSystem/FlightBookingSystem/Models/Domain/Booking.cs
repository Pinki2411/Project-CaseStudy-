using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystem.Models.Domain
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_id { get; set; }
        [Required]
        [StringLength(30)]
        public string Passenger_Name { get; set; }
        [Required]
        [StringLength(40)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string Country { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Passport_No Invalid")]
        public string Passport_No { get; set; }
        public string Gender { get; set; }
        [Required]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "PhoneNumber Must be 10 Digit Only")]

        public string PhoneNumber { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Age must be between 1-100 only")]
        public int Age { get; set; }
        [Required]
        public int ReferenceNo { get; set; }

        //Navigation Property
        [Required]
        public int Flight_Id { get; set; }
        [ForeignKey("Flight_Id")]
        public virtual Flight Flight { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual Registration Registration { get; set; }

        public virtual Checkin Checkin { get; set; }
    }
}

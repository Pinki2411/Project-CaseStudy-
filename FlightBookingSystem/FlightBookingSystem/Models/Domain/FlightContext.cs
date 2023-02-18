using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Models.Domain
{
    public class FlightContext:DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Checkin> checkins { get; set; }


    }
}

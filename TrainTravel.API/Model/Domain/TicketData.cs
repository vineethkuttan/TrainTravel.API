using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTravel.API.Model.Domain
{
    public class TicketData
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey("BookingId")]
        public Guid BookingId { get; set; } // Foreign key to Booking's Id
        public BookingsData? Booking { get; set; }
    }
}

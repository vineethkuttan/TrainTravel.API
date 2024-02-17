using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.Domain
{
    public class PassengerData
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        [Range(0, 7)]
        public int? preference { get; set; }

        [ForeignKey("TicketId")]
        public Guid TicketId { get; set; } // Foreign key to Booking's Id
        public TicketData? Ticket { get; set; }
    }
}

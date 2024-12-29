using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        [Required]
        public Guid VillaId { get; set; }
        [ForeignKey("VillaId")]
        public Villa? Villa { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        [Required]
        public double TotalCost { get; set; }
        public int Nights { get; set; }
        public string? Status { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateOnly CheckInDate { get; set; }
        [Required]
        public DateOnly CheckOutDate { get; set; }
        public bool IsPaymentSuccessful { get; set; } = false;
        public DateTime PaymentDate { get; set; }
        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; }
        public DateTime ActualCheckInDate { get; set; }
        public DateTime ActualCheckOutDate { get; set; }
        public int VillaNumber { get; set; }
        [NotMapped]
        public List<VillaNumber> VillaNumbers { get; set; }

    }
}

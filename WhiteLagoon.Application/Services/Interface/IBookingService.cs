using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IBookingService
    {
        Task<Booking> CreateBooking(Guid villaId, ApplicationUser user, DateOnly checkInDate, DateOnly checkOutDate, int nights);
        Task FinalizeBooking(Booking booking);
        Task<bool> CheckRoomAvailable(Booking booking);
        Task UpdateStatus(Guid bookingId, string bookingStatus, int villaNumber);
        Task<List<Booking>> GetBookingList();
        Task<Booking> GetBookingById(Guid bookingId);
        Task<List<VillaNumber>> GetAvailableVillaNumbers(Booking booking);
    }
}

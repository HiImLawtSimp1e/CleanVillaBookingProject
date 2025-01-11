using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVillaService _villaService;

        public BookingService(IUnitOfWork unitOfWork, IVillaService villaService)
        {
            _unitOfWork = unitOfWork;
            _villaService = villaService;
        }

        public async Task<Booking> CreateBooking(Guid villaId, ApplicationUser user, DateOnly checkInDate, DateOnly checkOutDate, int nights)
        {
            var villa = _villaService.GetVillaById(villaId);

            var booking = new Booking()
            {
                VillaId = villaId,
                Villa = villa,
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkOutDate,
                TotalCost = villa.Price * nights,
                UserId = user.Id,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Name = user.Name,
            };

            return booking;
        }

        public async Task FinalizeBooking(Booking booking)
        {
            var villa = _villaService.GetVillaById(booking.VillaId);

            booking.TotalCost = villa.Price * booking.Nights;
            booking.Status = SD.StatusPending;
            booking.BookingDate = DateTime.Now;

            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();
        }

        public async Task<bool> CheckRoomAvailable(Booking booking)
        {
            var villa = _villaService.GetVillaById(booking.VillaId);

            var villaNumbersList = _unitOfWork.VillaNumber.GetAll().ToList();
            var bookedVillas = _unitOfWork.Booking.GetAll(u => u.Status == SD.StatusApproved ||
            u.Status == SD.StatusCheckedIn).ToList();

            int roomAvailable = SD.VillaRoomsAvailable_Count
                (villa.Id, villaNumbersList, booking.CheckInDate, booking.Nights, bookedVillas);

            if (roomAvailable <= 0)
            {
                return false;
            }

            return true;
        }

        public async Task UpdateStatus(Guid bookingId, string bookingStatus, int villaNumber = 0)
        {
            var dbBooking = _unitOfWork.Booking.Get(m => m.Id == bookingId);

            if (dbBooking == null)
            {
                return;
            }

            dbBooking.Status = bookingStatus;

            if (bookingStatus == SD.StatusCheckedIn)
            {
                dbBooking.VillaNumber = villaNumber;
                dbBooking.ActualCheckInDate = DateTime.Now;
            }

            if (bookingStatus == SD.StatusCompleted)
            {
                dbBooking.ActualCheckOutDate = DateTime.Now;
            }

            _unitOfWork.Booking.Update(dbBooking);
            _unitOfWork.Save();
        }

        public async Task<Booking> GetBookingById(Guid bookingId)
        {
            var booking = _unitOfWork.Booking.Get(u => u.Id == bookingId,
               includeProperties: "User,Villa");

            return booking;
        }

        public async Task<List<Booking>> GetBookingList()
        {
            var bookings = _unitOfWork.Booking.GetAll(includeProperties: "User,Villa");

            return bookings.ToList();
        }

        public async Task<List<VillaNumber>> GetAvailableVillaNumbers(Booking booking)
        {
            // Lấy danh sách các số villa đã check-in
            var checkedInVillaNumbers = _unitOfWork.Booking
                .GetAll(u => u.VillaId == booking.VillaId && u.Status == SD.StatusCheckedIn)
                .Select(u => u.VillaNumber)
                .ToHashSet(); // Dùng HashSet để tối ưu hiệu năng khi tìm kiếm

            // Lọc ra các số villa khả dụng
            var availableVillaNumbers = _unitOfWork.VillaNumber
                .GetAll(u => u.VillaId == booking.VillaId && !checkedInVillaNumbers.Contains(u.Villa_Number))
                .ToList();

            return availableVillaNumbers;
        }
    }
}

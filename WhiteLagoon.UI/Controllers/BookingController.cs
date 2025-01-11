using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(IBookingService bookingService, UserManager<ApplicationUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> FinalizeBooking(Guid villaId, DateOnly checkInDate, DateOnly checkOutDate ,int nights)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            var booking = await _bookingService.CreateBooking(villaId, user, checkInDate, checkOutDate, nights);

            return View(booking);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FinalizeBooking(Booking booking)
        {
            bool roomAvailable = await _bookingService.CheckRoomAvailable(booking);

            if (!roomAvailable)
            {
                TempData["error"] = "Room has been sold out!";
                //no rooms available
                return RedirectToAction(nameof(FinalizeBooking), new
                {
                    villaId = booking.VillaId,
                    checkInDate = booking.CheckInDate,
                    checkOutDate = booking.CheckOutDate,
                    nights = booking.Nights
                });
            }

            await _bookingService.FinalizeBooking(booking);

            return RedirectToAction(nameof(BookingConfirmation), new { bookingId = booking.Id });
        }
        [Authorize]
        public async Task<IActionResult> BookingConfirmation(Guid bookingId)
        {
            var dbBooking = await _bookingService.GetBookingById(bookingId);

            if (dbBooking.Status == SD.StatusPending)
            {
                //payment business logic here (not yet)
                await _bookingService.UpdateStatus(dbBooking.Id, SD.StatusApproved, 0);
            }

            return View(bookingId);
        }

        [Authorize]
        public async Task<IActionResult> BookingDetails(Guid bookingId)
        {
            var booking = await _bookingService.GetBookingById(bookingId);

            if (booking.VillaNumber == 0 && booking.Status == SD.StatusApproved)
            {
                booking.VillaNumbers = await _bookingService.GetAvailableVillaNumbers(booking);
            }

            return View(booking);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> CheckIn(Booking booking)
        {
            await _bookingService.UpdateStatus(booking.Id, SD.StatusCheckedIn, booking.VillaNumber);

            TempData["Success"] = "Booking Updated Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> CheckOut(Booking booking)
        {
            await _bookingService.UpdateStatus(booking.Id, SD.StatusCompleted, booking.VillaNumber);

            TempData["Success"] = "Booking Completed Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> CancelBooking(Booking booking)
        {
            await _bookingService.UpdateStatus(booking.Id, SD.StatusCancelled, 0);

            TempData["Success"] = "Booking Cancelled Successfully.";
            return RedirectToAction(nameof(BookingDetails), new { bookingId = booking.Id });
        }

        #region API Calls
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(string status)
        {
            IEnumerable<Booking> objBookings;
            if (User.IsInRole(SD.Role_Admin))
            {
                objBookings = await _bookingService.GetBookingList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                objBookings = await _bookingService.GetBookingList();
            }
            if (!string.IsNullOrEmpty(status))
            {
                objBookings = objBookings.Where(u => u.Status.ToLower().Equals(status.ToLower()));
            }
            return Json(new { data = objBookings });
        }
        #endregion
    }
}

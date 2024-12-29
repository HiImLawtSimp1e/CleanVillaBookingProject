using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Utility
{
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Admin = "Admin";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusCheckedIn = "CheckedIn";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public static int VillaRoomsAvailable_Count(Guid villaId, List<VillaNumber> villaNumberList, DateOnly checkInDate, int nights, List<Booking> bookings)
        {
            // Danh sách chứa Id của các booking đã đặt
            List<Guid> bookingInDate = new();

            // Số phòng khả dụng tối thiểu ban đầu
            int finalAvailableRoomForAllNights = int.MaxValue;

            // Đếm số lượng phòng trong villa
            var roomsInVilla = villaNumberList.Where(x => x.VillaId == villaId).Count();

            // Xử lý cho từng ngày
            for (int i = 0; i < nights; i++)
            {
                // Lọc các booking trong ngày hiện tại
                var villasBooked = bookings.Where(u => u.CheckInDate <= checkInDate.AddDays(i)
                && u.CheckOutDate > checkInDate.AddDays(i) && u.VillaId == villaId);

                // Thêm booking Id vào danh sách nếu chưa tồn tại
                foreach (var booking in villasBooked)
                {
                    if (!bookingInDate.Contains(booking.Id))
                    {
                        bookingInDate.Add(booking.Id);
                    }
                }

                // Tính số phòng còn khả dụng
                var totalAvailableRooms = roomsInVilla - bookingInDate.Count;

                // Nếu không còn phòng khả dụng, trả về 0
                if (totalAvailableRooms == 0)
                {
                    return 0;
                }

                // Cập nhật số phòng khả dụng tối thiểu
                if (finalAvailableRoomForAllNights > totalAvailableRooms)
                {
                    finalAvailableRoomForAllNights = totalAvailableRooms;
                }
            }

            // Trả về số phòng khả dụng tối thiểu sau khi xử lý xong
            return finalAvailableRoomForAllNights;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Update(Booking entity);
        void UpdateStatus(Guid bookingId, string bookingStatus, int villaNumber);
        void UpdateStripePaymentID(Guid bookingId, string sessionId, string paymentIntentId);
    }
}

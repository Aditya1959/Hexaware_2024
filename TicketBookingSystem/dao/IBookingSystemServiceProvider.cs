using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public interface IBookingSystemServiceProvider
    {
        decimal CalculateBookingCost(int numTickets, Event eventDetails);
        void BookTickets(string eventName, int numTickets, Customer[] arrayOfCustomers);
        void CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }
}

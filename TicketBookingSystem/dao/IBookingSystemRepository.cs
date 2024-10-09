using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public interface IBookingSystemRepository
    {
        Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue);
        Event[] GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
        decimal CalculateBookingCost(int numTickets);
        void BookTickets(string eventName, int numTickets, Customer[] listOfCustomers);
        void CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public interface IEventServiceProvider
    {
        Event CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, int totalSeats, decimal ticketPrice, string eventType, Venue venue);
        Event[] GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
    }
}

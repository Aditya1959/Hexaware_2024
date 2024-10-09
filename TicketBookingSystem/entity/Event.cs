using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.entity
{
    public class Event
    {
        // Attributes
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string VenueName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; private set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; } // 'Movie', 'Sports', 'Concert'

        // Default constructor
        public Event()
        {
            AvailableSeats = TotalSeats; // Initialize available seats
        }

        // Overloaded constructor
        public Event(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            VenueName = venueName;
            TotalSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
            AvailableSeats = totalSeats; // Initialize available seats
        }

        // Method to calculate total revenue
        public decimal CalculateTotalRevenue(int ticketsSold)
        {
            return TicketPrice * ticketsSold;
        }

        // Method to get the number of booked tickets
        public int GetBookedNoOfTickets()
        {
            return TotalSeats - AvailableSeats;
        }

        // Method to book tickets
        public bool BookTickets(int numTickets)
        {
            if (numTickets <= AvailableSeats)
            {
                AvailableSeats -= numTickets;
                return true;
            }
            return false; // Not enough available seats
        }

        // Method to cancel booking
        public void CancelBooking(int numTickets)
        {
            AvailableSeats += numTickets;
        }

        // Method to display event details
        public virtual void  DisplayEventDetails()
        {
            Console.WriteLine($"Event: {EventName}, Date: {EventDate.ToShortDateString()}, Time: {EventTime}, Venue: {VenueName}");
            Console.WriteLine($"Total Seats: {TotalSeats}, Available Seats: {AvailableSeats}, Ticket Price: {TicketPrice:C}, Type: {EventType}");
        }
    }
}

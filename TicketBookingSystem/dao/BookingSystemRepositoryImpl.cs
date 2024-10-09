using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    private SqlConnection GetDBConn()
    {
        // Replace with your actual connection string
        string connectionString = "your_connection_string_here";
        return new SqlConnection(connectionString);
    }

    public Event CreateEvent(string eventName, DateTime date, TimeSpan time, int totalSeats, decimal ticketPrice, string eventType, Venue venue)
    {
        Event newEvent = null;

        using (SqlConnection conn = GetDBConn())
        {
            // Implement the SQL insert logic here
            // and return the created Event object.
        }

        return newEvent;
    }

    public Event[] GetEventDetails()
    {
        List<Event> events = new List<Event>();

        using (SqlConnection conn = GetDBConn())
        {
            // Implement the SQL select logic here
            // Populate the events list
        }

        return events.ToArray();
    }

    public int GetAvailableNoOfTickets(string eventName)
    {
        // Implement logic to return available tickets for the specified event
    }

    public decimal CalculateBookingCost(int numTickets)
    {
        // Implement logic to calculate total booking cost
    }

    public void BookTickets(string eventName, int numTickets, Customer[] listOfCustomers)
    {
        // Implement logic to book tickets and update the database
    }

    public void CancelBooking(int bookingId)
    {
        // Implement logic to cancel booking and update the database
    }

    public Booking GetBookingDetails(int bookingId)
    {
        // Implement logic to get booking details
    }
}
}

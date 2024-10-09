using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.entity
{
    public class Sports : Event
    {
        // Attributes
        public string SportName { get; set; }
        public string TeamsName { get; set; } // e.g., India vs Pakistan

        // Default constructor
        public Sports() { }

        // Overloaded constructor
        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public Sports(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string v) : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
        {
        }

        // Method to display sports details
        public void DisplaySportDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Sport: {SportName}, Teams: {TeamsName}");
        }

        public override void DisplayEventDetails()
        {
            DisplaySportDetails();
        }
    }
}

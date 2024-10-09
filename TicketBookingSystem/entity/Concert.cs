using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.entity
{
     public class Concert : Event
        {
            // Attributes
            public string Artist { get; set; }
            public string Type { get; set; } // Theatrical, Classical, Rock, Recital

            // Default constructor
            public Concert() { }

            // Overloaded constructor
            public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string artist, string type)
                : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
            {
                Artist = artist;
                Type = type;
            }

        public Concert(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string v) : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
        {
        }

        // Method to display concert details
        public void DisplayConcertDetails()
            {
                base.DisplayEventDetails();
                Console.WriteLine($"Artist: {Artist}, Type: {Type}");
            }

            public override void DisplayEventDetails()
            {
                DisplayConcertDetails();
            }
     }
}

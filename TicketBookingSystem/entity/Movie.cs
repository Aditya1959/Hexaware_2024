using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.entity
{
    public class Movie : Event
    {
        // Attributes
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        // Default constructor
        public Movie() { }

        // Overloaded constructor
        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string genre, string actorName, string actressName)
            : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
        {
            Genre = genre;
            ActorName = actorName;
            ActressName = actressName;
        }

        public Movie(string eventName, DateTime eventDate, TimeSpan eventTime, string venueName, int totalSeats, decimal ticketPrice, string eventType, string v1, string v2) : base(eventName, eventDate, eventTime, venueName, totalSeats, ticketPrice, eventType)
        {
        }

        // Method to display movie details
        public override void DisplayEventDetails()
        {
            base.DisplayEventDetails();
            Console.WriteLine($"Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
        }
    }
}

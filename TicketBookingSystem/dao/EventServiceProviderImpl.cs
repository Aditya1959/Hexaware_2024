using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public class EventServiceProviderImpl : IEventServiceProvider
    {
        private List<Event> events = new List<Event>();

        public Event CreateEvent(string eventName, DateTime eventDate, TimeSpan eventTime, int totalSeats, decimal ticketPrice, string eventType, Venue venue)
        {
            Event newEvent = null;
            switch (eventType.ToLower())
            {
                case "movie":
                    newEvent = new Movie(eventName, eventDate, eventTime, venue.VenueName, totalSeats, ticketPrice, "Action", "ActorExample", "ActressExample");
                    break;
                case "concert":
                    newEvent = new Concert(eventName, eventDate, eventTime, venue.VenueName, totalSeats, ticketPrice, "ArtistExample", "TypeExample");
                    break;
                case "sports":
                    newEvent = new Sports(eventName, eventDate, eventTime, venue.VenueName, totalSeats, ticketPrice, "SportNameExample", "Team1 vs Team2");
                    break;
                default:
                    Console.WriteLine("Invalid event type.");
                    break;
            }

            if (newEvent != null)
            {
                events.Add(newEvent);
            }
            return newEvent;
        }

        public Event[] GetEventDetails()
        {
            return events.ToArray();
        }

        public int GetAvailableNoOfTickets(string eventName)
        {
            var selectedEvent = events.Find(e => e.EventName == eventName);
            if (selectedEvent != null)
            {
                return selectedEvent.AvailableSeats;
            }
            else
            {
                Console.WriteLine("Event not found.");
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.entity;

namespace TicketBookingSystem.dao
{
    public class BookingSystemServiceProviderImpl : EventServiceProviderImpl, IBookingSystemServiceProvider
    {
        private List<Booking> bookings = new List<Booking>();
        private int bookingCounter = 1;

        public decimal CalculateBookingCost(int numTickets, Event eventDetails)
        {
            return numTickets * eventDetails.TicketPrice;
        }

        public void BookTickets(string eventName, int numTickets, Customer[] arrayOfCustomers)
        {
            Event eventToBook = GetEventDetails().FirstOrDefault(e => e.EventName == eventName);
            if (eventToBook != null)
            {
                if (eventToBook.AvailableSeats >= numTickets)
                {
                    eventToBook.AvailableSeats -= numTickets;
                    Booking newBooking = new Booking(bookingCounter++, eventToBook, numTickets, arrayOfCustomers);
                    bookings.Add(newBooking);
                    Console.WriteLine($"Booking successful. Booking ID: {newBooking.BookingId}, Remaining seats: {eventToBook.AvailableSeats}");
                }
                else
                {
                    Console.WriteLine("Not enough available seats.");
                }
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        public void CancelBooking(int bookingId)
        {
            Booking bookingToCancel = bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (bookingToCancel != null)
            {
                bookingToCancel.Event.AvailableSeats += bookingToCancel.NumTickets;
                bookings.Remove(bookingToCancel);
                Console.WriteLine($"Booking cancelled. Booking ID: {bookingId}, Seats returned: {bookingToCancel.NumTickets}");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        public Booking GetBookingDetails(int bookingId)
        {
            Booking booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                return booking;
            }
            else
            {
                Console.WriteLine("Booking not found.");
                return null;
            }
        }
    }
}

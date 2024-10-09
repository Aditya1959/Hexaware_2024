using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicketBookingSystem.exception.CustomException;
using TicketBookingSystem.dao;

namespace TicketBookingSystem.main
{
    internal class Mains
    {
        static void Main(string[] args)
        {
            //ITicketBookingDao ticketDao = new TicketBookingDao();

            // Task 3: Looping
            // Keep booking tickets until the user types "Exit"
            string userInput = string.Empty;
            while (userInput != "Exit")
            {
                // Task 1: Check Ticket Availability
                int availableTickets = ticketDao.GetAvailableTickets();
                Console.WriteLine($"Available tickets: {availableTickets}");

                Console.Write("Enter number of tickets to book: ");
                int noOfBookingTicket = Convert.ToInt32(Console.ReadLine());

                if (noOfBookingTicket <= availableTickets)
                {
                    // Task 2: Choose Ticket Category and Calculate Cost
                    Console.WriteLine("Choose a ticket category: ");
                    Console.WriteLine("1. Silver");
                    Console.WriteLine("2. Gold");
                    Console.WriteLine("3. Diamond");

                    Console.Write("Enter your choice (1/2/3): ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    string ticketCategory = string.Empty;
                    decimal basePrice = 0;

                    if (choice == 1)
                    {
                        ticketCategory = "Silver";
                        basePrice = ticketDao.GetTicketPrice(ticketCategory);  // Fetch price from DB
                    }
                    else if (choice == 2)
                    {
                        ticketCategory = "Gold";
                        basePrice = ticketDao.GetTicketPrice(ticketCategory);
                    }
                    else if (choice == 3)
                    {
                        ticketCategory = "Diamond";
                        basePrice = ticketDao.GetTicketPrice(ticketCategory);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice! Exiting.");
                        continue; // Skip the rest of the iteration and ask again
                    }

                    // Calculate total cost
                    decimal totalCost = basePrice * noOfBookingTicket;
                    Console.WriteLine($"Total cost for {noOfBookingTicket} {ticketCategory} ticket(s): {totalCost:C}");

                    // Update tickets in the database
                    int remainingTickets = availableTickets - noOfBookingTicket;
                    ticketDao.UpdateTickets(remainingTickets);

                    Console.WriteLine("Tickets booked successfully!");
                    Console.WriteLine($"Remaining tickets: {remainingTickets}");
                }
                else
                {
                    Console.WriteLine("Tickets unavailable.");
                }

                // Ask if user wants to continue booking or Exit
                Console.WriteLine("Type 'Exit' to stop or press Enter to book more tickets.");
                userInput = Console.ReadLine();
            }
            TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
            // Call the Main method to simulate ticket booking
            ticketBookingSystem.Main();

            //Task 9
            IEventServiceProvider eventServiceProvider = new EventServiceProviderImpl();
            TicketBookingSystem bookingSystem = new TicketBookingSystem(eventServiceProvider);

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. Cancel Booking");
                Console.WriteLine("3. View Booking Details");
                Console.WriteLine("4. Exit");

                string option = Console.ReadLine();
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter Event Name: ");
                            string eventName = Console.ReadLine();
                            Console.Write("Enter Number of Tickets: ");
                            int numTickets = int.Parse(Console.ReadLine());
                            bookingSystem.BookTickets(eventName, numTickets);
                            break;

                        case "2":
                            Console.Write("Enter Booking ID: ");
                            int bookingId = int.Parse(Console.ReadLine());
                            bookingSystem.CancelBooking(bookingId);
                            break;

                        case "3":
                            Console.Write("Enter Booking ID: ");
                            int viewBookingId = int.Parse(Console.ReadLine());
                            bookingSystem.ViewBookingDetails(viewBookingId);
                            break;

                        case "4":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (EventNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidBookingIDException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("An unexpected error occurred. Please try again.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}

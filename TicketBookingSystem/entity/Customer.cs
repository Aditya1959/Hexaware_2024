using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.entity
{
    public class Customer
    {
        // Attributes
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Default constructor
        public Customer() { }

        // Overloaded constructor
        public Customer(string customerName, string email, string phoneNumber)
        {
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Method to display customer details
        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer: {CustomerName}, Email: {Email}, Phone: {PhoneNumber}");
        }
    }
}

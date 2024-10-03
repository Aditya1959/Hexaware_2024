USE TicketBookingSystem;
GO

CREATE TABLE Venu (
    venue_id INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment for venue_id
    venue_name VARCHAR(100) NOT NULL,
    address VARCHAR(255) NOT NULL
);
CREATE TABLE Customer (
    customer_id INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment for customer_id
    customer_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE, -- Unique constraint for email
    phone_number VARCHAR(15) NOT NULL
);
CREATE TABLE Event (
    event_id INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment for event_id
    event_name VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_time TIME NOT NULL,
    venue_id INT NOT NULL,
    total_seats INT NOT NULL,
    available_seats INT NOT NULL,
    ticket_price DECIMAL(10, 2) NOT NULL,
    event_type VARCHAR(20) CHECK (event_type IN ('Movie', 'Sports', 'Concert')), -- Event type constraint

    CONSTRAINT FK_Venue FOREIGN KEY (venue_id) REFERENCES Venu(venue_id)
);
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY IDENTITY(1,1), -- Auto-increment for booking_id
    customer_id INT NOT NULL,
    event_id INT NOT NULL,
    num_tickets INT NOT NULL,
    total_cost DECIMAL(10, 2) NOT NULL,
    booking_date DATE NOT NULL,

    CONSTRAINT FK_Customer FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
    CONSTRAINT FK_Event FOREIGN KEY (event_id) REFERENCES Event(event_id)
);


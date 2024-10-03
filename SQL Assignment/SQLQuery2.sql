INSERT INTO Venu (venue_name, address) VALUES
('Grand Theatre', 'Connaught Place, New Delhi, Delhi 110001'),
('Stadium Arena', 'Mahatma Gandhi Road, Bangalore, Karnataka 560001'),
('Concert Hall', 'Marine Drive, Mumbai, Maharashtra 400020'),
('Open Air Theatre', 'Juhu Beach, Mumbai, Maharashtra 400049'),
('Community Center', 'Shankar Nagar, Nagpur, Maharashtra 440010'),
('Art Gallery', 'Sector 17, Chandigarh 160017'),
('City Park', 'Nehru Park, New Delhi, Delhi 110003'),
('Exhibition Center', 'Kolkata Maidan, Kolkata, West Bengal 700019'),
('Multipurpose Hall', 'Viman Nagar, Pune, Maharashtra 411014'),
('Civic Auditorium', 'Rashtrapati Bhavan, New Delhi, Delhi 110004');

select * from Venu;

INSERT INTO Event (event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type) VALUES
('Movie Night', '2024-10-15', '19:00:00', 1, 150, 100, 12.50, 'Movie'),
('Football Match', '2024-11-20', '15:00:00', 2, 50000, 45000, 25.00, 'Sports'),
('Live Concert', '2024-12-05', '20:00:00', 3, 2000, 1500, 30.00, 'Concert'),
('Shakespeare Play', '2024-10-25', '18:30:00', 4, 300, 200, 20.00, 'Movie'),
('Art Exhibition', '2024-11-01', '10:00:00', 6, 500, 400, 10.00, 'Concert'),
('Local Band Night', '2024-11-15', '19:30:00', 3, 1500, 1000, 15.00, 'Concert'),
('Outdoor Festival', '2024-10-10', '11:00:00', 7, 1000, 800, 5.00, 'Concert'),
('Charity Sports Event', '2024-12-10', '14:00:00', 2, 20000, 18000, 20.00, 'Sports'),
('Family Fun Day', '2024-11-05', '09:00:00', 5, 800, 600, 8.00, 'Movie'),
('New Year Gala', '2024-12-31', '22:00:00', 8, 1200, 1000, 50.00, 'Concert');

select * from Event;

INSERT INTO Customer (customer_name, email, phone_number) VALUES
('Aarav Sharma', 'aarav.sharma@domain.com', '555-0123'),
('Diya Patel', 'diya.patel@domain.com', '555-0456'),
('Vivaan Gupta', 'vivaan.gupta@domain.com', '555-0789'),
('Saanvi Reddy', 'saanvi.reddy@domain.com', '555-0101'),
('Reyansh Mehta', 'reyansh.mehta@domain.com', '555-1112'),
('Anaya Iyer', 'anaya.iyer@domain.com', '555-1314'),
('Krishna Nair', 'krishna.nair@domain.com', '555-1516'),
('Riya Bansal', 'riya.bansal@domain.com', '555-1718'),
('Aditya Singh', 'aditya.singh@domain.com', '555-1920'),
('Pooja Joshi', 'pooja.joshi@domain.com', '555-2122');

select * from Customer;

INSERT INTO Booking (customer_id, event_id, num_tickets, total_cost, booking_date) VALUES
(1, 1, 2, 25.00, '2024-10-01'),
(2, 2, 4, 100.00, '2024-10-05'),
(3, 3, 1, 30.00, '2024-10-07'),
(1, 4, 3, 60.00, '2024-10-10'),
(5, 5, 5, 50.00, '2024-10-12'),
(2, 6, 6, 90.00, '2024-10-15'),
(4, 7, 2, 10.00, '2024-10-20'),
(6, 8, 8, 160.00, '2024-10-22'),
(7, 9, 1, 8.00, '2024-10-25'),
(8, 10, 10, 500.00, '2024-10-30');

select * from Booking;

--2.2
SELECT event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type FROM Event;

--2.3
SELECT event_id, event_name, event_date, event_time, available_seats, ticket_price FROM Event WHERE available_seats > 0;

INSERT INTO Event (event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type) VALUES
('Cricket World Cup Final', '2024-11-25', '14:00:00', 2, 50000, 45000, 1500.00, 'Sports');

--2.4
SELECT event_id, event_name, event_date, event_time, ticket_price FROM Event WHERE event_name LIKE '%cup%';

--2.5
SELECT event_id, event_name, ticket_price FROM Event WHERE ticket_price BETWEEN 1000 AND 2500;

--2.6
SELECT event_id, event_name, event_date FROM Event WHERE event_date BETWEEN '2024-10-01' AND '2024-12-31';

--2.7
SELECT event_id, event_name, available_seats, ticket_price FROM Event WHERE available_seats > 0 AND event_name LIKE '%Concert%';

--2.8
SELECT customer_id, customer_name, email FROM Customer ORDER BY customer_id OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY;

--2.9
SELECT booking_id, customer_id, event_id, num_tickets, total_cost, booking_date FROM Booking WHERE num_tickets > 4;

--2.10
SELECT customer_id, customer_name, email, phone_number FROM Customer WHERE phone_number LIKE '%000';

--2.11
SELECT event_id, event_name, total_seats, available_seats FROM Event WHERE total_seats > 15000 ORDER BY event_name;

--2.12
SELECT event_id, event_name FROM Event WHERE event_name NOT LIKE 'x%' AND event_name NOT LIKE 'y%' AND event_name NOT LIKE 'z%';

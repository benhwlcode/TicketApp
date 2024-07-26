/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.Addresses)
begin

    insert into dbo.Addresses
    (Street, Municipal, Country)
    values
    ('1616 Williams Street', 'Stratford, Warwickshire', 'England'),
    ('315 Howard P. Lane', 'Providence, Rhode Island', 'United States')

end


if not exists (select 1 from dbo.Venues)
begin

    declare @addressId1 int;
    declare @addressId2 int;

    select @addressId1 =
        Id from dbo.Addresses
        where Street = '1616 Williams Street';

    select @addressId2 =
        Id from dbo.Addresses
        where Street = '315 Howard P. Lane';

    insert into dbo.Venues
    ([Name], [Description], SeatCount, AddressId)
    values
    ('Bards and Poet Theatre Hall', 
        'The main threatre hall at Bards and Poets where plays are performed.', 500, @addressId1),
    ('Bards and Poet Concert Hall', 
        'The main concert hall at Bards and Poets where musicals are performed.', 200, @addressId1),
    ('Cosmos Exhibition Hall', 
        'A large exhibition hall at Greenes Hotel allows up to 2000 visitors.', 2000, @addressId2)
end

if not exists (select 1 from dbo.[Events])
begin
    
    declare @venueId1 int;
    declare @venueId2 int;
    declare @venueId3 int;

    select @venueId1 =
        Id from dbo.Venues
        where [Name] = 'Bards and Poet Theatre Hall';

    select @venueId2 =
        Id from dbo.Venues
        where [Name] = 'Bards and Poet Concert Hall';

    select @venueId3 =
        Id from dbo.Venues
        where [Name] = 'Cosmos Exhibition Hall';

    insert into dbo.[Events]
    ([Name], [Description], DetailsLink, VenueId, 
        StartDate, StartTime, EndDate, EndTime)
    values
    ('Modern Macbeth', 
        'The classic tragic play reimagined in the modern day.', 'google.ca', @venueId1, 
        '2024-12-12', '18:00:00', '2024-12-12', '22:00:00'),
    ('John and Mary - First Live Performance', 
        'Local jazz band John and Mary begins their first tour.', 'google.ca', @venueId2, 
        '2024-12-12', '16:30:00', '2024-12-12', '20:30:00'),
    ('Science Fiction Conference 2024 Day 1', 
        'Day 1 of the largest sci-fi con in the US.', 'google.ca', @venueId3, 
        '2024-05-04', '09:00:00', '2019-05-04', '18:00:00'),
    ('Science Fiction Conference 2024 Day 2', 
        'Day 2 of the largest sci-fi con in the US.', 'google.ca', @venueId3, 
        '2019-05-05', '09:00:00', '2019-05-05', '18:00:00')

end 

if not exists (select 1 from dbo.Tickets)
begin

    declare @eventId1 int;
    declare @eventId2 int;
    declare @eventId3 int;
    declare @eventId4 int;

    select @eventId1 =
        Id from dbo.[Events]
        where [Name] = 'Modern Macbeth';

    select @eventId2 =
        Id from dbo.[Events]
        where [Name] = 'John and Mary - First Live Performance';

    select @eventId3 =
        Id from dbo.[Events]
        where [Name] = 'Science Fiction Conference 2024 Day 1';

    select @eventId4 =
        Id from dbo.[Events]
        where [Name] = 'Science Fiction Conference 2024 Day 2';

    insert into dbo.Tickets 
    (EventId, [Name], Price, MaxSeatsCount, PerGuestLimit, [Description])
    values
    (@eventId1, 'General Admission Ticket', 40.00, 500, 5, 
        'Tickets to see Modern Macbeth.'),
    (@eventId2, 'Live Ticket', 80.00, 200, 2, 
        'Tickets to see John and Mary live.'),
    (@eventId2, 'Streaming Ticket', 60.00, 9999, 1, 
        'Streaming ticket to see John and Mary online and includes access to archive.'),
    (@eventId3, 'Day One Normal Ticket', 120.00, 1800, 4, 
        'Tickets to enter Science Fiction Conference 2024 Day 1'),
    (@eventId3, 'Day One Premium-Pass', 200.00, 200, 2, 
        'Premium tickets including exclusive merch and access to exclusive exhibitions.'),
    (@eventId4, 'Day Two Normal Ticket', 120.00, 1800, 4, 
        'Tickets to enter Science Fiction Conference 2024 Day 2'),
    (@eventId4, 'Day Two Premium-Pass', 220.00, 200, 2, 
        'Premium tickets including exclusive merch and access to exclusive exhibitions.')


end
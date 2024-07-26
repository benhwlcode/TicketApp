CREATE TABLE [dbo].[Purchases]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TicketId] INT NOT NULL, 
    [GuestId] INT NOT NULL, 
    [SeatsPurchased] INT NOT NULL, 
    [ConfirmationCode] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Purchases_Tickets] FOREIGN KEY (TicketId) REFERENCES Tickets(Id), 
    CONSTRAINT [FK_Purchases_Guests] FOREIGN KEY (GuestId) REFERENCES Guests(Id)
)

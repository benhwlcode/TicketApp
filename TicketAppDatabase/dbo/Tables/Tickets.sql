CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [MaxSeatsCount] INT NOT NULL, 
    [SeatsSoldCount] INT NOT NULL DEFAULT 0, 
    [PerGuestLimit] INT NOT NULL,
    [Description] NVARCHAR(500) NOT NULL, 

    CONSTRAINT [FK_Tickets_Events] FOREIGN KEY (EventId) REFERENCES [Events](Id)

)

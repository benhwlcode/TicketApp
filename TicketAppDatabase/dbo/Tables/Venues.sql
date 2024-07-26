CREATE TABLE [dbo].[Venues]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [SeatCount] INT NOT NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [FK_Venues_Addresses] FOREIGN KEY (AddressId) REFERENCES Addresses(Id) 
)

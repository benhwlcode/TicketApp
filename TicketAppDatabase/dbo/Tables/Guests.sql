CREATE TABLE [dbo].[Guests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [IdentificationId] INT NOT NULL, 
    CONSTRAINT [FK_Guests_Identifications] FOREIGN KEY (IdentificationId) REFERENCES Identifications(Id) 
)

CREATE TABLE [dbo].[Identifications]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL
)

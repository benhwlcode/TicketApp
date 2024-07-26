CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Street] NVARCHAR(50) NOT NULL, 
    [Municipal] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL

)

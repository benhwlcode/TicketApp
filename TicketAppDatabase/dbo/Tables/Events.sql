CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [DetailsLink] NVARCHAR(50) NOT NULL, 
    [VenueId] INT NOT NULL,
    [StartDate] DATE NOT NULL, 
    [StartTime] TIME(0) NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [EndTime] TIME(0) NOT NULL, 
    [IsSoldOut] BIT NOT NULL DEFAULT 0, 
    [IsCompleted] BIT NOT NULL DEFAULT 0, 
    [Thumbnail] IMAGE NULL,
    CONSTRAINT [FK_Events_Venues] FOREIGN KEY (VenueId) REFERENCES Venues(Id)
)

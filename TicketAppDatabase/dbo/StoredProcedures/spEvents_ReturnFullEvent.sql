CREATE PROCEDURE [dbo].[spEvents_ReturnFullEvent]
	@eventId int
AS
begin
	set nocount on

	select e.[Name], e.[Description], e.DetailsLink,
		e.StartDate, e.StartTime, e.EndDate, e.EndTime,
		v.[Name] as VenueName,
		a.Street as AddressStreet,
		a.Municipal as AddressMunicipal,
		a.Country as AddressCountry
	from [Events] e
	inner join Venues v
	on v.Id = e.VenueId
	inner join Addresses a
	on a.Id = v.AddressId
	where e.Id = @eventId

end

CREATE PROCEDURE [dbo].[spTickets_ReturnAvailableTickets]
	@eventId int
AS

begin
	set nocount on

	select * from dbo.Tickets
	where SeatsSoldCount < MaxSeatsCount
	and EventId = @eventId

end

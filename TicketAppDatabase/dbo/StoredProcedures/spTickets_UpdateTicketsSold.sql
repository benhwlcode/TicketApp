CREATE PROCEDURE [dbo].[spTickets_UpdateTicketsSold]
	@seatsSold int,
	@ticketId int,
	@eventId int
AS
begin
	set nocount on

	update dbo.Tickets 
	set SeatsSoldCount = SeatsSoldCount + @seatsSold
	where Id = @ticketId

	if not exists (select 1 from dbo.Tickets 
		where MaxSeatsCount > SeatsSoldCount
		and EventId = @eventId)
	begin

		update dbo.[Events]
		set IsSoldOut = 1
		where Id = @eventId

	end


end

CREATE PROCEDURE [dbo].[spTickets_ReturnEventTickets]
	@eventId int
AS
begin
	set nocount on

	select * from dbo.Tickets
	where EventId = @eventId

end

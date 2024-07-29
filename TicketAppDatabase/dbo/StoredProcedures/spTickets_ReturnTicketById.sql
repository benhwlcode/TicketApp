CREATE PROCEDURE [dbo].[spTickets_ReturnTicketById]
	@ticketId int
AS
begin
	set nocount on

	select * from dbo.Tickets
	where Id = @ticketId

end

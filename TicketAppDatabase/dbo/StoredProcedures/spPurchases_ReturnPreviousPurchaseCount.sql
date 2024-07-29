CREATE PROCEDURE [dbo].[spPurchases_ReturnPreviousPurchaseCount]
	@ticketId int,
	@identificationId int

AS
begin
	set nocount on

	if exists (select 1 from dbo.Purchases p
		where p.TicketId = @ticketId
		and p.IdentificationId = @identificationId)
	begin

		select SUM(SeatsPurchased) from dbo.Purchases
		where IdentificationId = @identificationId

	end

	if not exists (select 1 from dbo.Purchases p
		where p.TicketId = @ticketId
		and p.IdentificationId = @identificationId)
	begin
		
		select 0

	end

end
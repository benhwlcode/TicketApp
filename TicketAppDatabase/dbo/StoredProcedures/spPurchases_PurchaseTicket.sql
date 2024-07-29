CREATE PROCEDURE [dbo].[spPurchases_PurchaseTicket]
	@ticketId int,
	@identificationId int,
	@seatsPurchased int,
	@confirmationCode nvarchar(50)


AS
begin
	set nocount on

	insert into dbo.Purchases
	(TicketId, IdentificationId, SeatsPurchased, ConfirmationCode)
	values
	(@ticketId, @identificationId, @seatsPurchased, @confirmationCode)

end

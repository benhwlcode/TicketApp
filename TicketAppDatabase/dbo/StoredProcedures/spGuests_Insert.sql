CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@identificationId int

AS
begin
	set nocount on

	if not exists(select 1 from dbo.Guests 
		where FirstName = @firstName 
		and LastName = @lastName
		and IdentificationId = @identificationId)
	begin

		insert into dbo.Guests (FirstName, LastName, IdentificationId)
		values (@firstName, @lastName, @identificationId)
	end


end

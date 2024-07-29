CREATE PROCEDURE [dbo].[spIdentifications_Insert]
	@phoneNumber nvarchar(50),
	@emailAddress nvarchar(50)

AS
begin
	set nocount on

	if not exists (select 1 from dbo.Identifications 
		where PhoneNumber = @phoneNumber 
		or EmailAddress = @emailAddress)
	begin
		
		insert into dbo.Identifications 
		(PhoneNumber, EmailAddress)
		values
		(@phoneNumber, @emailAddress)

	end

	

end

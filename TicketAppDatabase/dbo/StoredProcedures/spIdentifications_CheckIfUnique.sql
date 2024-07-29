CREATE PROCEDURE [dbo].[spIdentifications_CheckIfUnique]
	@phoneNumber nvarchar(50),
	@emailAddress nvarchar(50)
AS

begin
	set nocount on

	select 1 from Identifications
	where PhoneNumber = @phoneNumber
	or EmailAddress = @emailAddress

end

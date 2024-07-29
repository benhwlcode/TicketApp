CREATE PROCEDURE [dbo].[spIdentifications_ReturnId]
	@phoneNumber nvarchar(50),
	@emailAddress nvarchar(50)

AS
begin
	set nocount on

	select 1 Id from dbo.Identifications 
	where PhoneNumber = @phoneNumber
	and EmailAddress = @emailAddress

end

﻿CREATE PROCEDURE [dbo].[spEvents_ReturnAvailableEvents]
	@isSoldOut bit,
	@isCompleted bit,
	@countryName nvarchar(50)
AS

begin
	set nocount on

	select e.* from dbo.[Events] e
	inner join dbo.Venues v 
	on v.Id = e.VenueId
	inner join dbo.Addresses a
	on a.Id = v.AddressId
	where 
	e.IsSoldOut = @isSoldOut 
	and e.IsCompleted = @isCompleted
	and (@countryName = '' or a.Country = @countryName)

end
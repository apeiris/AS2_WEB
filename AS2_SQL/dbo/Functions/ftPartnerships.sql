create function ftPartnerships() returns table as return

select * from [dbo].[ftPartnershipsFromXml](dbo.fxPartnerships())
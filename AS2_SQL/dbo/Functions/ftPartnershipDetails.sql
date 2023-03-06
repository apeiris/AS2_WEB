
CREATE function [dbo].[ftPartnershipDetails](@PartnershipName varchar(100)) returns table as
return

select p.partnershipId,p.name,p.sender,p.receiver,attrName=a.name,a.value from partnerships p
join partnershipsAttributes a on p.PartnershipId=a.[PartnershipID]
where p.name=@partnershipName
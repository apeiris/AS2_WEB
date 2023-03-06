

CREATE     Procedure [dbo].[xmlToPartneshipTables](@partnershipName nvarchar(100)) as
--declare @partnershipname varchar(100)='c-to-d'
Begin
	declare @partnershipId int;
	declare @xml xml
	select @xml=xml_data from partnerships_xml where id=(select max(id) from partnerships_xml)
	select @xml
	select @partnershipId= PartnershipID from partnerships where name=@partnershipName
	delete from partnerships where  partnershipId=@partnershipID
	delete from partnershipsAttributes where  partnershipId= @partnershipId

	select @xml= xml_data from partnerships_xml where id=(select max(id) from partnerships_xml)
	--select @xml
	insert partnerships(name,sender,receiver,implementation_flavour,pollerConfig)
	SELECT partnership.value('@name', 'varchar(100)') AS name,
		   partnership.value('(sender/@name)[1]', 'varchar(100)') AS sender,
		   partnership.value('(receiver/@name)[1]', 'varchar(100)') AS receiver,
		   partnership.value('(@implementation_flavour)[1]', 'varchar(100)') AS implemetnation_flavour,
		   partnership.value('(pollerConfig/@enabled)[1]', 'varchar(100)') AS pollerConfig
	FROM @xml.nodes('/partnerships/partnership[@name=sql:variable("@partnershipName")]') AS partnerships(partnership)

select @partnershipId=SCOPE_IDENTITY();
insert partnershipsAttributes(partnershipId,name,value)
	SELECT @partnershipId,
		   attributes.value('@name', 'varchar(100)') AS [name],
		   attributes.value('@value', 'varchar(200)') AS [value]
	FROM @xml.nodes('/partnerships/partnership[@name=sql:variable("@partnershipname")]') AS partnerships(partnership)
	CROSS APPLY partnerships.partnership.nodes('attribute') AS attributes(attributes)
end;
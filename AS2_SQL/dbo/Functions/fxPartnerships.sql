CREATE function dbo.fxPartnerships() returns xml as
begin
return (
select
 xml_data from [dbo].[partnerships_xml] where id=(select max(id) from dbo.Partnerships_xml))
end
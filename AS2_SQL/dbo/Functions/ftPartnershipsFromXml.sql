

--declare @x xml
--select @x = dbo.fxpartnerships();
create function ftPartnershipsFromXml(@x xml) returns table as return
WITH CTE AS (
  SELECT  
    ROW_NUMBER() OVER(ORDER BY x.partnerships.value('@name','varchar(100)')) AS RowNumber,
    x.partnerships.value('@name','varchar(100)') AS PartnershipName
  FROM 
    @x.nodes('/partnerships/partnership') x(partnerships)
)
SELECT *
FROM CTE
CREATE PROCEDURE [dbo].[bulkloadXmlFile]
	
AS
begin
-- Load the XML data into the table
DECLARE @xml AS XML;
BEGIN TRY
SELECT @xml = CAST(bulkcolumn AS XML)
FROM OPENROWSET(BULK 'C:\Users\mapei\eclipse-workspace\OpenAs2App\Server\target\dist\config\partnerships.xml', SINGLE_BLOB) as x;
END TRY
BEGIN CATCH
PRINT 'Error: Unable to load XML file.';
END CATCH;

-- Insert the XML into the table
INSERT INTO partnerships_xml (xml_data)
VALUES (@xml);



DECLARE @PartnershipName varchar(100);

DECLARE partnerships_cursor CURSOR FOR
  SELECT  
    x.partnerships.value('@name','varchar(100)') AS PartnershipName
  FROM 
    @xml.nodes('/partnerships/partnership') x(partnerships);

OPEN partnerships_cursor;

FETCH NEXT FROM partnerships_cursor INTO @PartnershipName;

WHILE @@FETCH_STATUS = 0
BEGIN
  PRINT @PartnershipName;

  FETCH NEXT FROM partnerships_cursor INTO @PartnershipName;
END;

exec [dbo].[xmlToPartneshipTables] @partnershipname;
CLOSE partnerships_cursor;
DEALLOCATE partnerships_cursor;

end
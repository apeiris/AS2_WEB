-- CREATE PROCEDURE for selecting a single Partner by ID
CREATE PROCEDURE dbo.[GetPartnerById]
    @Partner_ID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM dbo.Partner
    WHERE Partner_ID = @Partner_ID;
END
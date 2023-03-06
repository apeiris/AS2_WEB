-- CREATE PROCEDURE for deleting an existing Partner
CREATE PROCEDURE dbo.DeletePartner
    @Partner_ID int
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Partner
    WHERE Partner_ID = @Partner_ID;
END
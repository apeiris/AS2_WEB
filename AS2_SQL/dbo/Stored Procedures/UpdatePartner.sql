
-- CREATE PROCEDURE for updating an existing Partner
CREATE PROCEDURE dbo.UpdatePartner
    @Partner_ID int,
    @PartnerName nvarchar(max),
    @AS2_ID nvarchar(max),
    @X509_Alias nvarchar(max),
    @Email nvarchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Partner
    SET PartnerName = @PartnerName,
        AS2_ID = @AS2_ID,
        X509_Alias = @X509_Alias,
        Email = @Email
    WHERE Partner_ID = @Partner_ID;
END
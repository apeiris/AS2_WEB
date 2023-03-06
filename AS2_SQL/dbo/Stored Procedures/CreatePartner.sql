CREATE PROCEDURE [dbo].[CreatePartner]
    @PartnerName nvarchar(max),
    @AS2_ID nvarchar(max),
    @X509_Alias nvarchar(max),
    @Email nvarchar(max),
    @LastCU_Time datetime2(7),
    @Partner_ID int OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Partner] (PartnerName, AS2_ID, X509_Alias, Email, LastCU_Time)
    VALUES (@PartnerName, @AS2_ID, @X509_Alias, @Email, @LastCU_Time);

    SET @Partner_ID = SCOPE_IDENTITY();
END
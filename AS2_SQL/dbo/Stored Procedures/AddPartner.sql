CREATE PROCEDURE [dbo].[AddPartner]
	@PartnerName nvarchar(max),
	@AS2_ID nvarchar(max),
	@X509_Alias nvarchar(max),
	@Email nvarchar(max)
AS
BEGIN
	INSERT INTO [dbo].[Partner] ([PartnerName], [AS2_ID], [X509_Alias], [Email]) 
	VALUES (@PartnerName, @AS2_ID, @X509_Alias, @Email);
END
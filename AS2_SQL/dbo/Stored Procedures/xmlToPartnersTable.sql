CREATE procedure [dbo].[xmlToPartnersTable] as
declare @x xml=dbo.fxPartnerships()

INSERT INTO Partners(PartnerName,AS2_ID,X509_Alias,Email)
SELECT 
    p.value('@name', 'varchar(50)') AS PartnerName,
    p.value('@as2_id', 'varchar(50)') AS AS2_ID,
    p.value('@x509_alias', 'varchar(50)') AS X509_Alias,
    p.value('@email', 'varchar(50)') AS Email
FROM 
    @x.nodes('/partnerships/partner') AS partners(p);
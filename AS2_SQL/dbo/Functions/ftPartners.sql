CREATE function [dbo].[ftPartners]() returns 
@t table([name] varchar(100),as2_id varchar(100),x509_alias varchar(100),email varchar(100)) as
Begin
-- The dbo.fxPartners() returns then definitions of  xml from  OPENAS2 config/partnerships.xml
  declare @x xml=dbo.fxPartnerships();
  with cte([name],as2_id,x509_alias,email)
  as
  (select 
	name=	r.c.value('./@name','varchar(100)'),
	as2_id=r.c.value('./@as2_id','varchar(100)'),
    x509_alias=r.c.value('./@x509_alias','varchar(100)'),
	email=r.c.value('./@email','varchar(100)')
	from @x.nodes('/partnerships/partner') r(c)
	)
 insert @t
 select * from cte
 return
end
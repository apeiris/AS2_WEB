
CREATE PROCEDURE [dbo].[GetPartners] @sortBy varchar(50) as
--declare @sortBy Varchar(50)='Partner_ID_ASC'
BEGIN
    SET NOCOUNT ON;
	declare @c char='_',@so varchar(5)='ASC',@sf varchar(50)
	if(dbo.fsSuffixAfterLast(@sortBy,@c) in('DESC','ASC'))
	  select @sf=dbo.fsPrefixBeforeLast(@sortBy,@c),@so=dbo.fsSuffixAfterLast(@sortby,@c)
	else
	  set @sf =@sortBy
    DECLARE @SQL nvarchar(max) ='SELECT * FROM partner ORDER BY '+QUOTENAME(@sf)+' '+@so
--	print @sql
   EXEC sp_executesql @sql
END
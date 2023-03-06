
create function dbo.fsPrefixBeforeLast(@s varchar(max),@c char) returns varchar(max) as

Begin
return  left(@s, charindex(dbo.fsSuffixAfterLast(@s,@c),@s)-2)
end;
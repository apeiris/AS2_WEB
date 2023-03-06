create FUNCTION [dbo].[fsSuffixAfterLast](@inputString VARCHAR(Max),@char char)
RETURNS VARCHAR(max)
AS
BEGIN
	if(charindex(@char,@inputstring) < 1) return ''
    DECLARE @lastUnderscoreIndex INT = LEN(@inputString) - CHARINDEX(@char, REVERSE(@inputString)) + 1;

    IF (@lastUnderscoreIndex > 0)
        set @inputString= RIGHT(@inputString, LEN(@inputString) - @lastUnderscoreIndex);
 
    RETURN @inputString;
END
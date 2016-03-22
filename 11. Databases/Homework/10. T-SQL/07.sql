--07. Define a function in the database TelerikAcademy that returns all Employee's names
--(first or middle or last name) and all town's names that are comprised of given set of letters.
--Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy

GO
CREATE FUNCTION ufn_CollectNamesComprisedOf(@characters NVARCHAR(50))
RETURNS @result TABLE(Name NVARCHAR(50))
AS BEGIN
	DECLARE @allNames TABLE(Name NVARCHAR(50))
	INSERT INTO @allNames
		SELECT FirstName FROM Employees
		UNION
		SELECT MiddleName FROM Employees
		UNION
		SELECT LastName FROM Employees
		UNION
		SELECT Name From Towns

	DECLARE @pattern NVARCHAR(54) = '%[' + @characters + ']%'

	INSERT INTO @result
		SELECT Name
		FROM @allNames
		WHERE Name LIKE @pattern

	RETURN
END

GO
DECLARE @res TABLE(Name NVARCHAR(50))


SELECT * FROM ufn_CollectNamesComprisedOf('oistmiahf')
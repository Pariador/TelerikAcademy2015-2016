--02. Create a stored procedure that accepts a number as a parameter and
--returns all persons who have more money in their accounts than the supplied number.

USE AccountsDB

GO
CREATE PROC usp_SelectPeopleWithBalanceMoreThan(@balance MONEY)
AS
	SELECT *
	FROM Persons p
	JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE Balance >= @balance

GO
EXEC usp_SelectPeopleWithBalanceMoreThan 17
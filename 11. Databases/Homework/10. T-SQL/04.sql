--04. Create a stored procedure that uses the function from the previous example to give an interest to a 
--person's account for one month. It should take the AccountId and the interest rate as parameters.

USE AccountsDB

GO
CREATE PROC usp_ApplyInterestRateForAMounth (@accountId INT, @percentYearlyInterestRate FLOAT)
AS BEGIN
	DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE Id = @accountId)

	DECLARE @newBalance MONEY
	EXEC @newBalance = ufn_CalcInterest @balance, @percentYearlyInterestRate, 1

	UPDATE Accounts
		SET Balance = @newBalance
		WHERE Id = @accountId
END

GO
EXEC usp_ApplyInterestRateForAMounth 1, 96

SELECT Balance
FROM Accounts
WHERE Id = 1
--03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.
USE AccountsDB

GO
CREATE FUNCTION ufn_CalcInterest(@amount MONEY, @percentYearlyInterestRate FLOAT, @numberOfMounths INT)
RETURNS MONEY
AS BEGIN
	DECLARE @totalPercentInterestRate FLOAT = (@percentYearlyInterestRate / 12) * @numberOfMounths
	RETURN @amount + ((@amount / 100) * @totalPercentInterestRate)
END

GO
DECLARE @result MONEY
EXEC @result = ufn_CalcInterest 100, 100, 12
PRINT @result
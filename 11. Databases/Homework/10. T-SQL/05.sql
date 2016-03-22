--05. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
USE AccountsDB

GO
CREATE PROC WithdrawMoney(@accountId INT, @amount MONEY)
AS BEGIN
	BEGIN TRAN Withdraw
		UPDATE Accounts
			SET Balance -= @amount
			WHERE Id = @accountId
	COMMIT TRAN Withdraw
END

GO
CREATE PROC DepositMoney(@accountId INT, @amount MONEY)
AS BEGIN
	BEGIN TRAN Deposit
		UPDATE Accounts
			SET Balance += @amount
			WHERE Id = @accountId
	COMMIT TRAN Deposit
END

GO
DECLARE @accountId INT = 1

SELECT Balance AS [Before Withdraw]
FROM Accounts
WHERE Id = @accountId

EXEC WithdrawMoney @accountId, 10

SELECT Balance AS [After Withdraw]
FROM Accounts
WHERE Id = @accountId

GO
DECLARE @accountId INT = 1

SELECT Balance AS [Before Deposit]
FROM Accounts
WHERE Id = @accountId

EXEC DepositMoney @accountId, 100

SELECT Balance AS [After Deposit]
FROM Accounts
WHERE Id = @accountId
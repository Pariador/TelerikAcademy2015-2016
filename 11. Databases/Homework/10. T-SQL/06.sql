--06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
USE AccountsDB

GO
CREATE TABLE Logs(
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	[OLD Sum] MONEY NOT NULL,
	[NEW Sum] MONEY NOT NULL
)

GO
CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	SELECT d.Id, d.Balance, i.Balance
	FROM inserted i
	JOIN deleted d
		ON i.Id = d.Id

GO
EXEC DepositMoney 1, 10

SELECT *
FROM Logs
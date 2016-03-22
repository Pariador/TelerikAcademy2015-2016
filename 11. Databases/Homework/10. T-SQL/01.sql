--01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.

CREATE AccountsDB

GO
USE AccountsDB

CREATE TABLE Persons(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN CHAR(9) NOT NULL CHECK(LEN(SSN) = 9) UNIQUE
)

GO
CREATE TABLE Accounts(
	Id INT IDENTITY PRIMARY KEY,
	PersonId INT NOT NULL FOREIGN KEY REFERENCES Persons(Id),
	Balance MONEY NOT NULL
)

GO
INSERT INTO Persons VALUES
	('John', 'Smith', '123456789'),
	('Acorn', 'West', '012345678'),
	('Annable', 'Spoonington', '987654321')

GO
INSERT INTO Accounts
SELECT Id, (Id * 17)
FROM Persons

GO
CREATE PROC usp_GetPersonsFullNames
AS
SELECT (FirstName + ' ' + LastName) AS FullName
FROM Persons

GO
EXEC usp_GetPersonsFullNames
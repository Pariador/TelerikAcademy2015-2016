--30. Start a database transaction, delete all employees from the 'Sales' department along with all
--dependent records from the pother tables. At the end rollback the transaction.

USE TelerikAcademy


BEGIN TRAN t
	DECLARE @salesEmployees TABLE(ID INT)
		INSERT INTO @salesEmployees
		SELECT e.EmployeeID
		FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'

	DECLARE @bigBossID INT = 
		(SELECT TOP 1 EmployeeID
		FROM Employees
		WHERE ManagerID IS NULL)

	UPDATE Employees
		SET ManagerID = @bigBossID
		WHERE ManagerID IN (SELECT ID FROM @salesEmployees)

	UPDATE Departments
		SET ManagerID = @bigBossID
		WHERE ManagerID IN (SELECT ID FROM @salesEmployees)
	
	DELETE
	FROM Employees
	WHERE EmployeeID IN (SELECT ID FROM @salesEmployees)
ROLLBACK TRAN t
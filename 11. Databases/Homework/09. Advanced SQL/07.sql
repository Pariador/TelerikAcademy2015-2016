--07. Write a SQL query to find the number of all employees that have manager.

USE TelerikAcademy

SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL
--09. Write a SQL query to find all departments and the average salary for each of them.

USE TelerikAcademy

SELECT d.Name, AvG(Salary) AS [Average Salary]
FROM Employees e
JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID, d.Name
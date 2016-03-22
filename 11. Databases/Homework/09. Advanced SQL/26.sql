--26. Write a SQL query to display the minimal employee salary by 
--department and job title along with the name of some of the employees that take it.

USE TelerikAcademy

SELECT d.Name AS Department, e.JobTitle, MIN(Salary) AS [Minimal Salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name, e.JobTitle

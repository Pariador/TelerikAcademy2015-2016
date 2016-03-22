--25. Write a SQL query to display the average employee salary by department and job title.

USE TelerikAcademy

SELECT d.Name AS Department, e.JobTitle, AVG(Salary) AS [Average Salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name, e.JobTitle
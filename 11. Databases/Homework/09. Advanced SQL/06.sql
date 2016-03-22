--06. Write a SQL query to find the number of employees in the "Sales" department.

USE TelerikAcademy

SELECT COUNT(*)
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
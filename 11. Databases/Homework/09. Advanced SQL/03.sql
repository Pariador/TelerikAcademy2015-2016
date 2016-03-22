--03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--Use a nested SELECT statement.

USE TelerikAcademy

SELECT (FirstName + ' ' + LastName) AS FullName, Salary, d.Name
FROM Employees e
JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(Salary) FROM Employees emp
	WHERE emp.DepartmentID = e.DepartmentID)

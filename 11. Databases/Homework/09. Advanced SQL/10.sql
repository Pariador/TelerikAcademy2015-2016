--10. Write a SQL query to find the count of all employees in each department and for each town.

USE TelerikAcademy

SELECT d.Name AS [Department Name], t.Name AS [Town Name], COUNT(*)
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.DepartmentID, d.Name, t.TownID, t.Name
ORDER BY d.Name
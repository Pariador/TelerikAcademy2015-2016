--28. Write a SQL query to display the number of managers from each town.

USE TelerikAcademy

SELECT t.Name AS Town, COUNT(*) AS [Manager Count]
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
JOIN Addresses a
	ON m.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.TownID, t.Name
--27. Write a SQL query to display the town where maximal number of employees work.

USE TelerikAcademy

SELECT TOP 1 t.Name AS [Town Name], COUNT(*) AS [Employees Count]
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.TownID, t.Name
ORDER BY [Employees Count] DESC
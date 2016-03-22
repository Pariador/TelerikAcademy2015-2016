--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

USE TelerikAcademy

SELECT m.FirstName, m.LastName, COUNT(*) AS EmployeeCount
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING COUNT(*) = 5
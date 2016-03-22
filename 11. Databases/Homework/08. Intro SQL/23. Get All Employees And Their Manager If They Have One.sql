USE TelerikAcademy

SELECT e.EmployeeID, e.FirstName, e.LastName, e.ManagerID, m.EmployeeID, (m.FirstName + ' ' + m.LastName) AS Manager
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID
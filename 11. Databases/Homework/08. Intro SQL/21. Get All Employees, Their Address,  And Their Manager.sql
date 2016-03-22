USE TelerikAcademy

SELECT 
	e.EmployeeID, 
	e.FirstName, 
	e.LastName, e.AddressID, 
	a.AddressID, 
	a.AddressText, 
	e.ManagerID, 
	m.EmployeeID, 
	(m.FirstName + ' ' + m.LastName) AS Manager
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID AND e.AddressID = a.AddressID
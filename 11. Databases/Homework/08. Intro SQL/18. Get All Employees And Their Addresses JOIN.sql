USE TelerikAcademy

SELECT *
FROM Employees
INNER JOIN Addresses
ON Addresses.AddressID = Employees.AddressID
USE TelerikAcademy

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DepartmentName
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE (e.HireDate >= '19950101' AND e.HireDate < '20060101')
AND (d.Name IN ('Sales', 'Finance'))
ORDER BY e.HireDate
--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.

INSERT INTO Users
SELECT 
	LOWER(LEFT(FirstName, 1) + LastName + CONVERT(nvarchar(100), EmployeeID)), 
	LOWER(LEFT(FirstName, 1) + LastName + '12345'),
	FirstName + ' ' + LastName,
	NULL,
	'Jedi'
FROM Employees
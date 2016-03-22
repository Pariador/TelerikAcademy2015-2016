--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.

USE TelerikAcademy

GO
CREATE VIEW UsersLoggedInToday AS
SELECT Username, LastLogin
FROM Users
WHERE CONVERT(date, GETDATE()) = CONVERT(date, LastLogin)

GO
SELECT *
FROM UsersLoggedInToday

GO
DROP VIEW UsersLoggedInToday
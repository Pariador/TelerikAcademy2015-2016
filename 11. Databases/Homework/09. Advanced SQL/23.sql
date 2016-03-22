--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

USE TelerikAcademy

UPDATE Users
SET Password = NULL
WHERE LastLogin <= '20100310'

SELECT Username, Password, LastLogin
FROM Users
WHERE LastLogin <= '20100310'
ORDER BY LastLogin
--24. Write a SQL statement that deletes all users without passwords (NULL password).

USE TelerikAcademy

DELETE Users
WHERE Password IS NULL
--21. Write SQL statements to delete some of the records from the Users and Groups tables.

USE TelerikAcademy

GO
DElETE FROM Groups
WHERE Name = 'Super Lame'

GO
DELETE FROM Users
WHERE Username LIKE '%a%'
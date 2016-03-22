--20. Write SQL statements to update some of the records in the Users and Groups tables.

USE TelerikAcademy

GO
UPDATE Groups
SET Name = 'Super Lame'
WHERE Name = 'Lame'

GO
UPDATE Users
SET LastLogin = GETDATE()
--18. Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

USE TelerikAcademy

ALTER TABLE Users
	ADD GroupName nvarchar(100) NOT NULL FOREIGN KEY REFERENCES Groups(Name)
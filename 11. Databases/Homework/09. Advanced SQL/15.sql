--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.

USE TelerikAcademy

CREATE TABLE Users (
	Username nvarchar(100) PRIMARY KEY,
	Password nvarchar(300) CHECK(LEN(Password) >= 5),
	FullName nvarchar(200) NOT NULL,
	LastLogin datetime
)
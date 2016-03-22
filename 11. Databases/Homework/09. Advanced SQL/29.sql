--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).

USE TelerikAcademy

CREATE TABLE WorkHours (
	ID INT IDENTITY PRIMARY KEY,
	EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeID),
	Task NVARCHAR(50) NOT NULL,
	[Date] DATE NOT NULL DEFAULT GETDATE(),
	[Hours] INT NOT NULL DEFAULT 8,
	Comments nvarchar(500)
)

GO
CREATE TABLE WorkHoursLogs (
	ID INT IDENTITY PRIMARY KEY,
	Command nvarchar(6) NOT NULL CHECK(Command IN ('insert', 'update', 'delete')),
	WorkHourID INT NOT NULL,

	[OLD EmployeeID] INT,
	[OLD Task] NVARCHAR(50),
	[OLD Date] DATE,
	[OLD Hours] INT,
	[OLD Comments] nvarchar(500),

	[NEW EmployeeID] INT,
	[NEW Task] NVARCHAR(50),
	[NEW Date] DATE,
	[NEW Hours] INT,
	[NEW Comments] nvarchar(500)
)

GO
CREATE TRIGGER tr_INSERT_WorkhoursLog ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLogs(Command, WorkHourID, [NEW EmployeeID], [NEW Task], [NEW Date], [NEW Hours], [NEW Comments])
	SELECT 'insert', ID, EmployeeID, Task, Date, Hours, Comments
	FROM inserted

GO
CREATE TRIGGER tr_DELETE_WorkhoursLog ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLogs(Command, WorkHourID, [OLD EmployeeID], [OLD Task], [OLD Date], [OLD Hours], [OLD Comments])
	SELECT 'delete', ID, EmployeeID, Task, Date, Hours, Comments
	FROM deleted

GO
CREATE TRIGGER tr_UPDATE_WorkhoursLog ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLogs
	SELECT 'update', d.ID, d.EmployeeID, d.Task, d.Date, d.Hours, d.Comments, i.EmployeeID, i.Task, i.Date, i.Hours, i.Comments
	FROM inserted i
	JOIN deleted d
		ON i.ID = d.ID

GO
INSERT INTO Workhours (EmployeeID, Task) VALUES
(1, 'Being Awesome'),
(65, 'Being Lazy'),
(61, 'Being a Vampire'),
(19, 'Being a Vamprie Huntah')

GO
UPDATE WorkHours
SET Hours = 24
WHERE Task = 'Being a Vampire'

GO
DELETE WorkHours
WHERE Task = 'Being Lazy'

GO
SELECT *
FROM WorkHours

GO
SELECT *
FROM WorkHoursLogs
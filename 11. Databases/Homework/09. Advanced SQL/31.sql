--31. Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?

USE TelerikAcademy

BEGIN TRAN t
	DROP TABLE EmployeesProjects
ROLLBACK TRAN t

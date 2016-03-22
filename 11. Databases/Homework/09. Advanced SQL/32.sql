--32. Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

USE TelerikAcademy

SELECT * 
INTO #EmployeesProjectsBackUp 
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects (
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
	ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID)

	CONSTRAINT PK_EmployeesProjects PRIMARY KEY (EmployeeID, ProjectID)
)

INSERT INTO EmployeesProjects
SELECT *
FROM #EmployeesProjectsBackUp

DROP TABLE #EmployeesProjectsBackUp

SELECT * 
FROM EmployeesProjects